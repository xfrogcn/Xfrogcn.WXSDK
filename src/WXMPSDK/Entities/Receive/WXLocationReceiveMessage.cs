using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    public class WXLocationReceiveMessage : WXReceiveMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Location;
            set => base.MsgType = WXMsgTypes.Location;
        }

        [XmlElement(ElementName = "Location_X")]
        public double Location_X { get; set; }

        [XmlElement(ElementName = "Location_Y")]
        public double Location_Y { get; set; }

        /// <summary>
        /// 地图缩放大小
        /// </summary>
        [XmlElement(ElementName = "Scale")]
        public double Scale { get; set; }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        [XmlElement(ElementName = "Label")]
        public string Label { get; set; }

        public override string Action => "发送位置消息";
    }
}
