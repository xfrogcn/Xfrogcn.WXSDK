using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    public class WXEventMessageBase : WXMessageBase
    {
        /// <summary>
        /// 消息类型固定为event
        /// </summary>
        public override string MsgType { get => WXMsgTypes.Event; set => base.MsgType = WXMsgTypes.Event; }

        /// <summary>
        /// 事件类型
        /// </summary>
        [XmlElement(ElementName = "Event")]
        public virtual string Event { get; set; }

        
    }
}
