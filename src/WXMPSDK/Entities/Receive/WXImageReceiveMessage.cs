using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 图片消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXImageReceiveMessage : WXReceiveMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Image;
            set => base.MsgType = WXMsgTypes.Image;
        }

        /// <summary>
        /// 图片链接（由系统生成）
        /// </summary>
        [XmlElement(ElementName = "PicUrl")]
        public string PicUrl { get; set; }

        /// <summary>
        /// 图片消息媒体id，可以调用获取临时素材接口拉取数据。
        /// </summary>
        [XmlElement(ElementName = "MediaId")]
        public string MediaId { get; set; }

        public override string Action => "发送图片消息";
    }
}
