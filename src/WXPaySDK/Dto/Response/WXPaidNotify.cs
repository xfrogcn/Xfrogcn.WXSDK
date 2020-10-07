using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [Serializable]
    [XmlRoot("xml")]
    public class WXPaidNotify : WXPayResponseBase
    {
        [XmlElement("appid")]
        public string AppId { get; set; }

        [XmlElement("mch_id")]
        public string MchId { get; set; }

        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }

        [XmlElement("sign_type")]
        public string SignType { get; set; }

        [XmlElement("openid")]
        public string OpenId { get; set; }

        [XmlElement("is_subscribe")]
        public string IsSubscribe { get; set; }

        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        [XmlElement("bank_type")]
        public string BankType { get; set; }

        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        [XmlElement("settlement_total_fee")]
        public int SettlementTotalFee { get; set; }

        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        [XmlElement("cash_fee")]
        public int CashFee { get; set; }

        [XmlElement("cash_fee_type")]
        public string CashFeeType { get; set; }

        [XmlElement("coupon_fee")]
        public int CouponFee { get; set; }

        [XmlElement("coupon_count")]
        public int CouponCount { get; set; }

        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        [XmlElement("attach")]
        public string Attach { get; set; }

        [XmlElement("time_end")]
        public string TimeEnd { get; set; }


        public static WXPaidNotify FromXml(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WXPaidNotify));

            return serializer.Deserialize(stream) as WXPaidNotify;
        }
    }
}
