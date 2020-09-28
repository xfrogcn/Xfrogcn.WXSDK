using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [Serializable]
    public class WXSendPicsInfo
    {
        /// <summary>
        /// 发送的图片数量
        /// </summary>
        [XmlElement(ElementName = "Count")]
        public int Count { get; set; }

        /// <summary>
        /// 图片列表
        /// </summary>
     //   [XmlArrayItem(typeof(WXPicItem))]
        [XmlArray(ElementName = "PicList")]
        [XmlArrayItem(ElementName = "item")]
        public List<WXPicItem> PicList { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    [Serializable]
    public class WXPicItem
    {
        /// <summary>
        /// 图片的MD5值，开发者若需要，可用于验证接收到图片
        /// </summary>
        [XmlElement(ElementName = "PicMd5Sum")]
        public string PicMd5Sum { get; set; }
    }
}
