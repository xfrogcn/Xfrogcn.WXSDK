using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 模版消息发送完成通知
    /// </summary>
    public class WXTemplateJobFinishEventMessage : WXEventMessageBase
    {
        public override string Event
        {
            get => WXMsgEventNames.TemplateSendJobFinish;
            set => base.Event = WXMsgEventNames.TemplateSendJobFinish;
        }

        [XmlElement(ElementName = "MsgID")]
        public long MsgID { get; set; }

        /// <summary>
        /// 完成状态，
        /// success
        /// failed:user block
        /// failed: system failed
        /// </summary>
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
    }
}
