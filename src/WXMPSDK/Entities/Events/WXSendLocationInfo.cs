using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "SendLocationInfo")]
    [Serializable]
    public class WXSendLocationInfo
    {
        /// <summary>
        /// X坐标信息
        /// </summary>
        [XmlElement(ElementName = "Location_X")]
        public double Location_X { get; set; }

        /// <summary>
        /// Y坐标信息
        /// </summary>
        [XmlElement(ElementName = "Location_Y")]
        public double Location_Y { get; set; }

        /// <summary>
        /// 精度，可理解为精度或者比例尺、越精细的话 scale越高
        /// </summary>
        [XmlElement(ElementName = "Scale")]
        public double Scale { get; set; }

        /// <summary>
        /// 地理位置的字符串信息
        /// </summary>
        [XmlElement(ElementName = "Label")]
        public string Label { get; set; }

        /// <summary>
        /// 朋友圈POI的名字，可能为空
        /// </summary>
        [XmlElement(ElementName = "Poiname")]
        public string Poiname { get; set; }
    }

}
