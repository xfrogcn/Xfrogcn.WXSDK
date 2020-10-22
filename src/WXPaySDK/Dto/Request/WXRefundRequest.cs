using System;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [XmlRoot("xml")]
    [Serializable]
    public class WXRefundRequest : WXPayRequestBase
    {
        /// <summary>
        /// 微信的订单号，建议优先使用
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。 详见商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
        /// </summary>
        [XmlElement("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 订单总金额，单位为分，只能为整数
        /// </summary>
        [XmlElement("total_fee")]
        public int? TotalFee { get; set; }

        /// <summary>
        /// 退款总金额，订单总金额，单位为分，只能为整数
        /// </summary>
        [XmlElement("refund_fee")]
        public int? RefundFee { get; set; }

        /// <summary>
        /// 退款货币类型，需与支付一致，或者不填。符合ISO 4217标准的三位字母代码，默认人民币：CNY，
        /// </summary>
        [XmlElement("refund_fee_type")]
        public string RefundFeeType { get; set; }

        /// <summary>
        /// 若商户传入，会在下发给用户的退款消息中体现退款原因
        /// 注意：若订单退款金额≤1元，且属于部分退款，则不会在退款消息中体现退款原因
        /// </summary>
        [XmlElement("refund_desc")]
        public string RefundDesc { get; set; }

        /// <summary>
        /// 异步接收微信支付退款结果通知的回调地址，通知URL必须为外网可访问的url，不允许带参数
        /// 如果参数中传了notify_url，则商户平台上配置的回调地址将不会生效。
        /// </summary>
        [XmlElement("notify_url")]
        public string NotifyUrl { get; set; }
    }
}
