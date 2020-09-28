using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXMusicReplyMessage : WXMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.Music;
            set => base.MsgType = WXMsgTypes.Music;
        }

        [XmlElement(ElementName = "Music")]
        public MusicMessageContent Music { get; set; }
    }

    [XmlRoot(ElementName = "Music")]
    public class MusicMessageContent
    {
        /// <summary>
        /// 音乐标题
        /// </summary>
        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// 音乐描述
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// 音乐链接
        /// </summary>
        [XmlElement(ElementName = "MusicUrl")]
        public string MusicUrl { get; set; }

        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
        /// </summary>
        [XmlElement(ElementName = "HQMusicUrl")]
        public string HQMusicUrl { get; set; }

        /// <summary>
        /// 缩略图的媒体id，通过素材管理中的接口上传多媒体文件，得到的id
        /// </summary>
        [XmlElement(ElementName = "ThumbMediaId")]
        public string ThumbMediaId { get; set; }
    }
}
