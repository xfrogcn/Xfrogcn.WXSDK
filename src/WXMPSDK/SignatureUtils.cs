using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WXMPSDK
{
    public static class SignatureUtils
    {
        public static string Signature(IDictionary<string,string> values)
        {
            SortedList<string, KeyValuePair<string, string>> sortedList = new SortedList<string, KeyValuePair<string, string>>();
            foreach(var kv in values)
            {
                sortedList.Add(kv.Key, kv);
            }
            string str = string.Join("&", sortedList.Values.Select(kv => $"{kv.Key}={kv.Value}"));
            var sha1 = SHA1.Create();
            byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
            string sha1Str = BitConverter.ToString(bytes).Replace("-", "").ToLower();

            return sha1Str;
        }
    }
}
