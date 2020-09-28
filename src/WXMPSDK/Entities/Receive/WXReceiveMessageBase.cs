using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 接收到的用户消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXReceiveMessageBase : WXMessageBase
    {
        [XmlElement(ElementName = "MsgId")]
        public  string MsgId { get; set; }
    }
}
