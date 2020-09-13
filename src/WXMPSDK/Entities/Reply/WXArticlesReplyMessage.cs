using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    public class WXArticlesReplyMessage : WXMessageBase
    {
        public override string MsgType
        {
            get => WXMsgTypes.News;
            set => base.MsgType = WXMsgTypes.News;
        }

        /// <summary>
        /// 图文消息个数；当用户发送文本、图片、语音、视频、图文、地理位置这六种消息时，开发者只能回复1条图文消息；其余场景最多可回复8条图文消息
        /// </summary>
        [XmlElement(ElementName = "ArticleCount")]
        public int ArticleCount { get; set; }

        /// <summary>
        /// 图文消息信息，注意，如果图文数超过限制，则将只发限制内的条数
        /// </summary>
        [XmlElement(ElementName = "Articles")]
        public ArticlesMessageContent Articles { get; set; }
    }

    [XmlRoot(ElementName = "Articles")]
    public class ArticlesMessageContent
    {
        [XmlElement(ElementName = "item")]
        public List<ArticleItem> Items { get; set; }
    }


    public class ArticleItem
    {
        /// <summary>
        /// 图文消息标题
        /// </summary>
        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// 图文消息描述
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// </summary>
        [XmlElement(ElementName = "PicUrl")]
        public string PicUrl { get; set; }

        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        [XmlElement(ElementName = "Url")]
        public string Url { get; set; }
    }
}
