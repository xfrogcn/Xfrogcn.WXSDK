using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    public class WXLinkReceiveMessage : WXReceiveMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Link;
            set => base.MsgType = WXMsgTypes.Link;
        }

        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Url")]
        public string Url { get; set; }

        public override string Action => "发送链接消息";
    }
}
