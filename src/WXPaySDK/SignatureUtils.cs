using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using WXPaySDK.Dto;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace WXPaySDK
{
    public static class SignatureUtils
    {
        private static ConcurrentDictionary<Type, Func<object,string, string>> signFuncCache =
            new ConcurrentDictionary<Type, Func<object,string, string>>();

        public static string Signature(object obj, string key)
        {
            Type t = obj.GetType();
            var func = signFuncCache.GetOrAdd(t, (t) =>
            {
                return generateFunc(t);
            });
            return func(obj, key);
        }


        public static string GetSignature(this WXPayBase dto, string key)
        {
            return Signature(dto, key);
        }

        public static void ComputeAndSetSign(this WXPayBase dto, string key)
        {
            string sign = dto.GetSignature(key);
            dto.Sign = sign;
        }

        public static bool ValidSignature(this WXPayBase dto, string key)
        {
            string sign = dto.GetSignature(key);
            return sign == dto.Sign;
        }

        private static Func<object, string, string> generateFunc(Type t)
        {
            var pis = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            ParameterExpression p1 = Expression.Parameter(typeof(object));
            ParameterExpression p2 = Expression.Parameter(typeof(string));
            List<Expression> expList = new List<Expression>();

            ParameterExpression dicVar = Expression.Variable(typeof(SortedDictionary<string, string>));
            MethodInfo addMethod = typeof(SortedDictionary<string, string>).GetMethod(nameof(SortedDictionary<string, string>.Add), BindingFlags.Instance | BindingFlags.Public);
            expList.Add(Expression.Assign(dicVar, Expression.New(typeof(SortedDictionary<string, string>))));
            foreach (var pi in pis)
            {
                string pn = pi.Name;
                var attrs = pi.GetCustomAttribute<XmlElementAttribute>();
                if (attrs != null && !string.IsNullOrEmpty(attrs.ElementName))
                {
                    pn = attrs.ElementName;
                }
                var access = Expression.MakeMemberAccess(Expression.Convert(p1, t), pi);
                if (pi.PropertyType == typeof(string))
                {
                    expList.Add(Expression.Call(
                        dicVar,
                        addMethod,
                        Expression.Constant(pn),
                        access));
                }
                else
                {
                    MethodInfo toStringMethod = pi.PropertyType.GetMethod(
                        nameof(ToString),
                        new Type[] { });

                    expList.Add(Expression.Call(
                        dicVar,
                        addMethod,
                        Expression.Constant(pn),
                        Expression.Call(access, toStringMethod)));
                }
            }

            MethodInfo smethod = typeof(SignatureUtils).GetMethod(nameof(signatureDic), BindingFlags.NonPublic | BindingFlags.Static);

            expList.Add(Expression.Call(smethod, dicVar, p2));

            return Expression.Lambda<Func<object, string, string>>(
                Expression.Block(
                    new ParameterExpression[] { dicVar },
                    expList
                    ),
                p1, p2
                ).Compile();

        }

        private static string signatureDic(SortedDictionary<string, string> dic, string key)
        {
           
            string signType = "MD5";
            StringBuilder sb = new StringBuilder();
            foreach(var kv in dic)
            {
                if (kv.Key == "sign")
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(kv.Value))
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("&");
                    }
                    sb.Append(kv.Key).Append("=").Append(kv.Value);
                    if( kv.Key == "sign_type")
                    {
                        signType = kv.Value;
                    }
                }
            }
            sb.Append("&key=").Append(key);

            string stringA = sb.ToString();

            HashAlgorithm hash = null;
            if (signType == "MD5")
            {
                hash = MD5.Create();
            }
            else if (signType == "HMAC-SHA256")
            {
                hash = SHA256.Create();
            }
            if (hash != null)
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(stringA));
                string hashStr = BitConverter.ToString(bytes).Replace("-", "").ToUpper();
                return hashStr;
            }
            return string.Empty;
        }
    }
}
