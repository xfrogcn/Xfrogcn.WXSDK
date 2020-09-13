using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 文本消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXTextReceiveMessage : WXReceiveMessageBase
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

        public override string Action => "发送文本消息";
    }
}
