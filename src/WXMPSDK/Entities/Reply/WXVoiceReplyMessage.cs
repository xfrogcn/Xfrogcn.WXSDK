using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    public class WXVoiceReplyMessage : WXMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Voice;
            set => base.MsgType = WXMsgTypes.Voice;
        }

        [XmlElement(ElementName = "Voice")]
        public VoiceMessageContent Voice { get; set; }
    }

    [XmlRoot(ElementName = "Voice")]
    public class VoiceMessageContent
    {
        [XmlElement(ElementName = "MediaId")]
        public string MediaId { get; set; }
    }
}
