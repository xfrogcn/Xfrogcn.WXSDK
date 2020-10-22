using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [XmlRoot("xml")]
    [Serializable]
    public class WXRefundResponse : WXPayResponseBase
    {
        [XmlElement("appid")]
        public string AppId { get; set; }

        [XmlElement("mch_id")]
        public string MchId { get; set; }

        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        [XmlElement("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 退款总金额,单位为分,可以做部分退款
        /// </summary>
        [XmlElement("refund_fee")]
        public int? RefundFee { get; set; }

        /// <summary>
        /// 去掉非充值代金券退款金额后的退款金额，退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [XmlElement("settlement_refund_fee")]
        public int? SettlementRefundFee { get; set; }

        [XmlElement("total_fee")]
        public int? TotalFee { get; set; }

        /// <summary>
        /// 去掉非充值代金券金额后的订单总金额，应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public int? SettlementTotalFee { get; set; }

        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        [XmlElement("cash_fee")]
        public int? CashFee { get; set; }

        [XmlElement("cash_fee_type")]
        public string CashFeeType { get; set; }

        [XmlElement("cash_refund_fee")]
        public int? CashRefundFee { get; set; }

        //TODO 代金卷

        [XmlElement("coupon_refund_count")]
        public int? CouponRefundCount { get; set; }
    }
}
