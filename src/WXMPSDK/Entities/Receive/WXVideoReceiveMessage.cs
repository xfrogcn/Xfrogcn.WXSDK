using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    public class WXVideoReceiveMessage : WXReceiveMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Video;
            set => base.MsgType = WXMsgTypes.Video;
        }

        [XmlElement(ElementName = "MediaId")]
        public string MediaId { get; set; }

        [XmlElement(ElementName = "ThumbMediaId")]
        public string ThumbMediaId { get; set; }

        public override string Action => "发送视频消息";
    }
}
