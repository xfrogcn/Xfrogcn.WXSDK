using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    public class WXVoiceReceiveMessage : WXReceiveMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Voice;
            set => base.MsgType = WXMsgTypes.Voice;
        }

        [XmlElement(ElementName = "MediaId")]
        public string MediaId { get; set; }

        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        [XmlElement(ElementName = "Format")]
        public string Format { get; set; }

        /// <summary>
        /// 语音识别后文本
        /// </summary>
        [XmlElement(ElementName = "Recognition", IsNullable = true)]
        public string Recognition { get; set; }


        public override string Action => "发送语音消息";
    }
}
