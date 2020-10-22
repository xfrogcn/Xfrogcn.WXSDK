using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXCloseOrderRequest : WXPayRequestBase
    {
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }
    }
}
