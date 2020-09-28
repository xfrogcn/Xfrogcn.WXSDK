using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXEventKeyMessageBase : WXEventMessageBase
    {
        /// <summary>
        /// 事件KEY值，
        /// 带参数二维码： qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        [XmlElement(ElementName = "EventKey", IsNullable = true)]
        public string EventKey { get; set; }
    }
}
