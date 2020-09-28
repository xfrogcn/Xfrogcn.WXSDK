using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXVideoReplyMessage : WXMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Video;
            set => base.MsgType = WXMsgTypes.Video;
        }

        [XmlElement(ElementName = "Video")]
        public VideoMessageContent Video { get; set; }
    }


    [XmlRoot(ElementName = "Video")]
    public class VideoMessageContent
    {
        [XmlElement(ElementName = "MediaId")]
        public string MediaId { get; set; }

        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

    }
}
