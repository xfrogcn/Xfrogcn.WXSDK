using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 小视频消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXShortVideoReceiveMessage : WXReceiveMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.ShortVideo;
            set => base.MsgType = WXMsgTypes.ShortVideo;
        }

        [XmlElement(ElementName = "MediaId")]
        public string MediaId { get; set; }

        [XmlElement(ElementName = "ThumbMediaId")]
        public string ThumbMediaId { get; set; }

        public override string Action => "发送小视频消息";
    }
}
