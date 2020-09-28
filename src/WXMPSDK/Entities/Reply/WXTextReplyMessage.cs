using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXTextReplyMessage : WXMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Text;
            set => base.MsgType = WXMsgTypes.Text;
        }

        /// <summary>
        /// 文本消息内容
        /// </summary>
        [XmlElement(ElementName = "Content")]
        public string Content { get; set; }
    }
}
