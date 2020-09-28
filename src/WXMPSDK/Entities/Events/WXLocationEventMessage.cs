using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 上报地理位置事件
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXLocationEventMessage : WXEventMessageBase
    {
        public override string Event
        {
            get => WXMsgEventNames.Location;
            set => base.Event = WXMsgEventNames.Location;
        }
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        [XmlElement(ElementName = "Latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        [XmlElement(ElementName = "Longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        [XmlElement(ElementName = "Precision")]
        public double Precision { get; set; }

        public override string Action => "上报地理位置";
    }
}
