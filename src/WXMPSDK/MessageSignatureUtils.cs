using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WXMPSDK
{
    public static class MessageSignatureUtils
    {

        public static string ComputeSignature(string timestamp, string nonce, string token)
        {
            List<string> list = new List<string>() { timestamp, nonce, token };
            list.Sort();

            string str = string.Join("", list);
            var sha1 = SHA1.Create();
            byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
            string sha1Str = BitConverter.ToString(bytes).Replace("-", "").ToLower();

            return sha1Str;
        }

        public static bool ValidSignature(string timestamp, string nonce, string signature, string token)
        {
            string sha1Str = ComputeSignature(timestamp, nonce, token);

            bool isOk = sha1Str.Equals(signature, StringComparison.OrdinalIgnoreCase);

            return isOk;
        }
    }
}
