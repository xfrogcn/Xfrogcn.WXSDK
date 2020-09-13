using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 用户已关注时的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXScanEventMessage : WXEventKeyMessageBase
    {
        public override string Event
        {
            get => WXMsgEventNames.Scan;
            set => base.Event = WXMsgEventNames.Scan;
        }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        [XmlElement(ElementName = "Ticket", IsNullable = true)]
        public string Ticket { get; set; }

        public override string Action => "扫关注二维码";
    }
}
