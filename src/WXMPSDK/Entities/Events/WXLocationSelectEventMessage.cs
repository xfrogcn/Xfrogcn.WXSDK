using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 弹出地理位置选择器的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXLocationSelectEventMessage : WXEventKeyMessageBase
    {
        public override string Event
        {
            get => WXMsgEventNames.LocationSelect;
            set => base.Event = WXMsgEventNames.LocationSelect;
        }

        /// <summary>
        /// 发送的位置信息
        /// </summary>
        [XmlElement(ElementName = "SendLocationInfo")]
        public WXSendLocationInfo SendLocationInfo { get; set; }


        public override string Action => "选择地理位置";
    }
}
