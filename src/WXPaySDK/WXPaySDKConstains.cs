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

        /// <summary>
        /// 支付成功
        /// </summary>
        public const string TRAD_STATE_SUCCESS = "SUCCESS";
        /// <summary>
        /// 转入退款
        /// </summary>
        public const string TRAD_STATE_REFUND = "REFUND";
        /// <summary>
        /// 未支付
        /// </summary>
        public const string TRAD_STATE_NOTPAY = "NOTPAY";
        /// <summary>
        /// 已关闭
        /// </summary>
        public const string TRAD_STATE_CLOSED = "CLOSED";
        /// <summary>
        /// 已撤销（付款码支付）
        /// </summary>
        public const string TRAD_STATE_REVOKED = "REVOKED";
        /// <summary>
        /// 用户支付中（付款码支付）
        /// </summary>
        public const string TRAD_STATE_USERPAYING = "USERPAYING";
        /// <summary>
        /// 支付失败(其他原因，如银行返回失败)
        /// </summary>
        public const string TRAD_STATE_PAYERROR = "PAYERROR";

        public const string LIMIT_PAY_NO_CREDIT = "no_credit";

        public const string WXPAY_URL = "https://api.mch.weixin.qq.com/";
    }
}
