using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXMenuDefine
    {
        [JsonPropertyName("button")]
        public List<MenuItem> Buttons { get; set; }
    }

    public class MenuViewLimitedButton: MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.ViewLimited;

        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
    }

    public class MenuMediaIdButton: MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.MediaId;

        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
    }

    public class MenuLocationSelectButton : MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.LocationSelect;
    }

    public class MenuPicWeiXinButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.PicWeiXin;
    }

    public class MenuPicPhotoOrAlbumButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.PicPhotoOrAlbum;
    }

    public class MenuPicSysPhotoButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.PicSysPhoto;
    }


    public class MenuScanCodePushButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.ScanCodePush;
    }

    public class MenuScanCodeWaitMsgButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.ScanCodeWaitMsg;
    }

    public class MenuMiniProgramButton: MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.MiniProgram;

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }
    }

    public class MenuViewButton: MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.View;

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class MenuClickButton : MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.Click;

        [JsonPropertyName("key")]
        public string Key { get; set; }
    }

    public class MenuContainer : MenuItem
    {
        [JsonPropertyName("sub_button")]
        public List<MenuItem> SubButtons { get; set; }
    }

    
    public class MenuButtonBase : MenuItem
    {
        [JsonPropertyName("type")]
        public virtual MenuButtonTypeEnum Type { get; }

    }

    [JsonConverter(typeof(WXMenuButtonConverter))]
    public class MenuItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    [JsonConverter(typeof(MenuButtonTypeEnumConverter))]
    public enum MenuButtonTypeEnum
    {
        
        Click,
        View,
        MiniProgram,
        ScanCodeWaitMsg,
        ScanCodePush,
        PicSysPhoto,
        PicPhotoOrAlbum,
        PicWeiXin,
        LocationSelect,
        MediaId,
        ViewLimited
    }

    public class MenuButtonTypeEnumConverter : JsonConverter<MenuButtonTypeEnum>
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

        private static Dictionary<string, MenuButtonTypeEnum> enumMapper
            = new Dictionary<string, MenuButtonTypeEnum>();

        static MenuButtonTypeEnumConverter()
        {
            foreach(var kv in buttonTypeMapper)
            {
                enumMapper.Add(kv.Value, kv.Key);
            }
        }

        public override MenuButtonTypeEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string str = reader.GetString().ToLower();
            return enumMapper[str];
        }

        public override void Write(Utf8JsonWriter writer, MenuButtonTypeEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(buttonTypeMapper[value]);
        }
    }
}
