using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    ///关注事件
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXSubscribeEventMessage : WXEventKeyMessageBase
    {
        public override string Event {
            get => WXMsgEventNames.Subscribe;
            set => base.Event = WXMsgEventNames.Subscribe;
        }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        [XmlElement(ElementName = "Ticket", IsNullable = true)]
        public string Ticket { get; set; }

        public override string Action => "关注公众号";
    }
}
