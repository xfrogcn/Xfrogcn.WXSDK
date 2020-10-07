using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [Serializable]
    [XmlRoot("xml")]
    public class WXUnifiedOrderResponse : WXPayResponseBase
    {
        [XmlElement("appid")]
        public string AppId { get; set; }

        [XmlElement("mch_id")]
        public string MchId { get; set; }

        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }

        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        [XmlElement("prepay_id")]
        public string PrePayId { get; set; }

        [XmlElement("code_url")]
        public string CodeUrl { get; set; }
    }
}
