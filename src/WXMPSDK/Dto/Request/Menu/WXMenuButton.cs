﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXMenuButtonConverter : JsonConverter<MenuItem>
    {
        private static Dictionary<MenuButtonTypeEnum, string> buttonTypeMapper
            = new Dictionary<MenuButtonTypeEnum, string>()
            {
                { MenuButtonTypeEnum.Click, "click" },
                { MenuButtonTypeEnum.View, "view" },
                { MenuButtonTypeEnum.MiniProgram, "miniprogram" },
                { MenuButtonTypeEnum.ScanCodeWaitMsg, "scancode_waitmsg" },
                { MenuButtonTypeEnum.ScanCodePush, "scancode_push" },
                { MenuButtonTypeEnum.PicSysPhoto, "pic_sysphoto" },
                { MenuButtonTypeEnum.PicPhotoOrAlbum, "pic_photo_or_album" },
                { MenuButtonTypeEnum.PicWeiXin, "pic_weixin" },
                { MenuButtonTypeEnum.LocationSelect, "location_select" },
                { MenuButtonTypeEnum.MediaId, "media_id" },
                { MenuButtonTypeEnum.ViewLimited, "view_limited" },
            };

        class MapItem
        {
            public MapItem(Type t)
            {
                Type = t;
            }

            public Type Type { get; set; }

           // public Action<MenuItem, Dictionary<string, object>> Setter { get; set; }

            public Func<Dictionary<string, object>, MenuItem> Creator { get; set; }


            public Dictionary<string, Action<MenuItem, object>> PropertyValueSetter { get; set; }

            public Dictionary<string, Action<Utf8JsonWriter, MenuItem>> PropertyWriter { get; set; }
        }

        private static Dictionary<MenuButtonTypeEnum, MapItem> enumToTypeMapper
            = new Dictionary<MenuButtonTypeEnum, MapItem>()
            {
                { MenuButtonTypeEnum.Click, new MapItem(typeof(MenuClickButton)) },
                { MenuButtonTypeEnum.View, new MapItem(typeof(MenuViewButton))  },
                { MenuButtonTypeEnum.MiniProgram, new MapItem(typeof(MenuMiniProgramButton)) },
                { MenuButtonTypeEnum.ScanCodeWaitMsg, new MapItem(typeof(MenuScanCodeWaitMsgButton))  },
                { MenuButtonTypeEnum.ScanCodePush, new MapItem(typeof(MenuScanCodePushButton))  },
                { MenuButtonTypeEnum.PicSysPhoto, new MapItem(typeof(MenuPicSysPhotoButton))  },
                { MenuButtonTypeEnum.PicPhotoOrAlbum, new MapItem(typeof(MenuPicPhotoOrAlbumButton) ) },
                { MenuButtonTypeEnum.PicWeiXin, new MapItem(typeof(MenuPicWeiXinButton))  },
                { MenuButtonTypeEnum.LocationSelect, new MapItem(typeof(MenuLocationSelectButton))  },
                { MenuButtonTypeEnum.MediaId, new MapItem(typeof(MenuMediaIdButton))  },
                { MenuButtonTypeEnum.ViewLimited, new MapItem(typeof(MenuViewLimitedButton))  },
            };

        private static Dictionary<string, MenuButtonTypeEnum> enumMapper
            = new Dictionary<string, MenuButtonTypeEnum>(StringComparer.OrdinalIgnoreCase);

        private static Dictionary<string, Type> propertyTypesMap = new Dictionary<string, Type>();
        
        static WXMenuButtonConverter()
        {
            foreach (var kv in buttonTypeMapper)
            {
                enumMapper.Add(kv.Value, kv.Key);
            }

            var writePropertyNameMethod = typeof(Utf8JsonWriter).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m =>
                {
                    if (m.Name == nameof(Utf8JsonWriter.WritePropertyName))
                    {
                        var parList = m.GetParameters();
                        if (parList.Length == 1 && parList[0].ParameterType == typeof(string))
                        {
                            return true;
                        }
                    }
                    return false;
                }).FirstOrDefault();
                  
                   

            foreach(var kv in enumToTypeMapper)
            {
                kv.Value.PropertyValueSetter = new Dictionary<string, Action<MenuItem, object>>(StringComparer.OrdinalIgnoreCase);
                kv.Value.PropertyWriter = new Dictionary<string, Action<Utf8JsonWriter, MenuItem>>();

                Expression newExpression = Expression.New(kv.Value.Type);
                ParameterExpression mi = Expression.Variable(typeof(MenuItem), "mi");
                ParameterExpression p = Expression.Parameter(typeof(Dictionary<string, object>));

                var body = Expression.Block(
                    new[] { mi },
                    Expression.Assign(mi, newExpression),
                    Expression.Call(null, typeof(WXMenuButtonConverter).GetMethod(nameof(SetItemProperty), System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic), mi, p),
                    mi
                    );
               kv.Value.Creator =   Expression.Lambda<Func<Dictionary<string, object>, MenuItem>>(body, p).Compile();

                var pis = kv.Value.Type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                foreach(var pi in pis)
                {
                    string name = pi.Name;
                    name = name.Substring(0, 1).ToLower() + (name.Length > 1 ? name.Substring(1) : string.Empty);
                    var attr = pi.GetCustomAttributes(typeof(JsonPropertyNameAttribute), true).OfType<JsonPropertyNameAttribute>().FirstOrDefault();
                    if (attr != null && !string.IsNullOrEmpty(attr.Name))
                    {
                        name = attr.Name;
                    }


                    // 写入
                    ParameterExpression miPar = Expression.Parameter(typeof(MenuItem));
                    ParameterExpression writerPar = Expression.Parameter(typeof(Utf8JsonWriter));

                    ParameterExpression v1 = Expression.Variable(pi.PropertyType, "pv");
                    var b1 = Expression.Assign(v1, Expression.MakeMemberAccess(Expression.Convert(miPar, kv.Value.Type), pi));
                    // 写属性名
                    var writePropertyName = Expression.Call(writerPar, writePropertyNameMethod, Expression.Constant(name));
                    // 写属性值
                    var writeValue = Expression.Call(null,
                        typeof(WXMenuButtonConverter).GetMethod(nameof(WritePropertyValue), BindingFlags.Static | BindingFlags.NonPublic),
                        writerPar,
                        Expression.Convert(v1, typeof(object)));

                    var writeProc = Expression.Lambda<Action<Utf8JsonWriter, MenuItem>>(
                        Expression.Block(
                        new[] { v1 },
                        b1,
                        writePropertyName,
                        writeValue), writerPar, miPar).Compile();
                    kv.Value.PropertyWriter.Add(name, writeProc);


                    // 读取
                    if (!pi.CanWrite)
                    {
                        continue;
                    }
                    ParameterExpression p1 = Expression.Parameter(typeof(MenuItem));
                    ParameterExpression p2 = Expression.Parameter(typeof(object));

                    Expression exp = Expression.Convert(p1, kv.Value.Type);
                    var eq = Expression.Assign(Expression.Property(exp, pi), Expression.Convert(p2, pi.PropertyType));

                    

                   kv.Value.PropertyValueSetter.Add(name, Expression.Lambda<Action<MenuItem, object>>(eq, p1, p2).Compile());

                    if(!propertyTypesMap.ContainsKey(name))
                    {
                        propertyTypesMap.Add(name, pi.PropertyType);
                    }
                }
            }
        }

        private static object GetPropertyValue(ref Utf8JsonReader reader, Type type)
        {
            if (type == typeof(string))
            {
                return reader.GetString();
            }
            else if (type == typeof(long))
            {
                return reader.GetInt64();
            }
            else if (type == typeof(int))
            {
                return reader.GetInt32();
            }
            else if (type == typeof(uint))
            {
                return reader.GetUInt32();
            }
            else if (type == typeof(ulong))
            {
                return reader.GetUInt64();
            }
            else if (type == typeof(short))
            {
                return reader.GetInt16();
            }
            else if (type == typeof(ushort))
            {
                return reader.GetUInt16();
            }
            else if (type == typeof(byte))
            {
                return reader.GetByte();
            }
            else if (type == typeof(bool))
            {
                return reader.GetBoolean();
            }
            else if (type == typeof(double))
            {
                return reader.GetDouble();
            }
            else if (type == typeof(decimal))
            {
                return reader.GetDecimal();
            }
            else if (type == typeof(DateTime))
            {
                return reader.GetDateTime();
            }
            else if (type == typeof(DateTimeOffset))
            {
                return reader.GetDateTimeOffset();
            }
            else if (type == typeof(Single))
            {
                return reader.GetSingle();
            }
            else if (type == typeof(sbyte))
            {
                return reader.GetSByte();
            }
            else if (type == typeof(Guid))
            {
                return reader.GetGuid();
            }else if(type == typeof(List<MenuItem>))
            {
                
            }

            throw new NotSupportedException(nameof(type));
        }

        private static void WritePropertyValue(Utf8JsonWriter writer, object val)
        {
            if(val == null)
            {
                writer.WriteNullValue();
                return;
            }
            var type = val.GetType();

            if(type == typeof(MenuButtonTypeEnum))
            {
                writer.WriteStringValue(buttonTypeMapper[(MenuButtonTypeEnum)val]);
            }else if (type == typeof(string))
            {
                writer.WriteStringValue(val as string);
            }
            else if (type == typeof(long))
            {
                writer.WriteNumberValue((long) val);
            }
            else if (type == typeof(int))
            {
                writer.WriteNumberValue((int)val);
            }
            else if (type == typeof(uint))
            {
                writer.WriteNumberValue((uint)val);
            }
            else if (type == typeof(ulong))
            {
                writer.WriteNumberValue((ulong)val);
            }
            else if (type == typeof(short))
            {
                writer.WriteNumberValue((short)val);
            }
            else if (type == typeof(ushort))
            {
                writer.WriteNumberValue((ushort)val);
            }
            else if (type == typeof(byte))
            {
                writer.WriteNumberValue((byte)val);
            }
            else if (type == typeof(bool))
            {
                writer.WriteBooleanValue((bool)val);
            }
            else if (type == typeof(double))
            {
                writer.WriteNumberValue((double)val);
            }
            else if (type == typeof(decimal))
            {
                writer.WriteNumberValue((decimal)val);
            }
            else if (type == typeof(DateTime))
            {
                writer.WriteStringValue((DateTime)val);
            }
            else if (type == typeof(DateTimeOffset))
            {
                writer.WriteStringValue((DateTimeOffset)val);
            }
            else if (type == typeof(Single))
            {
                writer.WriteNumberValue((Single)val);
            }
            else if (type == typeof(sbyte))
            {
                writer.WriteNumberValue((sbyte)val);
            }
            else if (type == typeof(Guid))
            {
                writer.WriteStringValue((Guid)val);
            }
            else
            {
                throw new NotSupportedException(nameof(type));
            }

            
        }


        private static void SetItemProperty(MenuItem mi, Dictionary<string, object> values)
        {
            var mapItem =  enumToTypeMapper.FirstOrDefault(kv => kv.Value.Type == mi.GetType()).Value;
            foreach(var kv in values)
            {
                Action<MenuItem, object> setter = null;
                if( mapItem.PropertyValueSetter.TryGetValue(kv.Key, out setter))
                {
                    setter(mi, kv.Value);
                }
            }
        }


        public override MenuItem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            Utf8JsonReader r = new Utf8JsonReader(reader.ValueSpan, reader.IsFinalBlock, reader.CurrentState);
            // Utf8JsonReader newReader = new Utf8JsonReader(reader.ValueSequence.Slice(reader.TokenStartIndex));
            MenuButtonTypeEnum? buttonType  = MenuButtonTypeEnum.Click;
            Dictionary<string, object> values = new Dictionary<string, object>();
            while (reader.Read())
            {
                if(reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }
                if(reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();
                    if ("type".Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                    {
                        string typeName = reader.GetString();
                        if(enumMapper.ContainsKey(typeName))
                        {
                            buttonType = enumMapper[typeName];
                        }
                    }
                    else
                    {
                        if(propertyTypesMap.ContainsKey(propertyName))
                        {
                            values.Add(propertyName, GetPropertyValue(ref reader, propertyTypesMap[propertyName]));
                        }
                        
                    }
                }
            }
            
            if (buttonType == null)
            {
                return null;
            }

            MapItem mi = enumToTypeMapper[buttonType.Value];
            return mi.Creator(values);
        }

        public override void Write(Utf8JsonWriter writer, MenuItem value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value.GetType() == typeof(MenuItem))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(value.Name);
                writer.WriteEndObject();
                return;
            }
            else if (value is MenuContainer mc)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(mc.Name);
                JsonSerializer.Serialize(writer, mc.SubButtons, typeof(List<MenuItem>), options);
                writer.WriteEndObject();
                return;
            }

            MenuButtonBase btnBase = value as MenuButtonBase;
            if(btnBase == null)
            {
                writer.WriteEndObject();
                return;
            }

            if (enumToTypeMapper.ContainsKey(btnBase.Type))
            {
                var mi = enumToTypeMapper[btnBase.Type];
                foreach(var pw in mi.PropertyWriter)
                {
                    pw.Value(writer, btnBase);
                }
            }

            writer.WriteEndObject();
        }
    }
}
