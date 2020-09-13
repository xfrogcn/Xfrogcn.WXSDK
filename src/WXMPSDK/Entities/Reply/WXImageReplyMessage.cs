using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    public class WXImageReplyMessage : WXMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Image;
            set => base.MsgType = WXMsgTypes.Image;
        }

        [XmlElement(ElementName = "Image")]
        public ImageMessageContent Image { get; set; }
    }

    [XmlRoot(ElementName = "Image")]
    public class ImageMessageContent
    {
        [XmlElement(ElementName = "MediaId")]
        public string MediaId { get; set; }
    }
}
