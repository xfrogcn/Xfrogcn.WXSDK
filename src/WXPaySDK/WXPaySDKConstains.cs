using System;
using System.Collections.Generic;
using System.Text;

namespace WXPaySDK
{
    public class WXPaySDKConstains
    {
        public const string SIGN_METHOD_MD5 = "MD5";
        public const string SIGN_METHOD_SHA256 = "HMAC-SHA256";

        public const string FEE_TYPE_CNY = "CNY";

        public const string TRADE_TYPE_JSAPI = "JSAPI";
        public const string TRADE_TYPE_NATIVE = "NATIVE";
        public const string TRADE_TYPE_APP = "APP";

        public const string LIMIT_PAY_NO_CREDIT = "no_credit";

        public const string WXPAY_URL = "https://api.mch.weixin.qq.com/";
    }
}
