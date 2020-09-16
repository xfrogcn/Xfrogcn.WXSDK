using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 新增图文素材请求
    /// </summary>
    public class WXAddNewsRequest
    {
        [JsonPropertyName("articles")]
        public List<WXAddNewsRequestArticleItem> Articles { get; set; }
    }

    public class WXAddNewsRequestArticleItem
    {
        /// <summary>
        /// 标题
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 图文消息的封面图片素材id（必须是永久mediaID）
        /// </summary>
        [JsonPropertyName("thumb_media_id")]
        public string ThumbMediaId { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [JsonPropertyName("author")]
        public string Author { get; set; }

        /// <summary>
        /// 图文消息的摘要，仅有单图文消息才有摘要，多图文此处为空。如果本字段为没有填写，则默认抓取正文前64个字。
        /// </summary>
        [JsonPropertyName("digest")]
        public string Digest { get; set; }

        /// <summary>
        /// 是否显示封面，0为false，即不显示，1为true，即显示
        /// </summary>
        [JsonPropertyName("show_cover_pic")]
        public int ShowCoverPic { get; set; }

        /// <summary>
        /// 图文消息的具体内容，支持HTML标签，必须少于2万字符，小于1M，且此处会去除JS,涉及图片url必须来源 "上传图文消息内的图片获取URL"接口获取。外部图片url将被过滤。
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// 图文消息的原文地址，即点击“阅读原文”后的URL
        /// </summary>
        [JsonPropertyName("content_source_url")]
        public string ContentSourceUrl { get; set; }

        /// <summary>
        /// Uint32 是否打开评论，0不打开，1打开
        /// </summary>
        [JsonPropertyName("need_open_comment")]
        public int NeedOpenComment { get; set; }

        /// <summary>
        /// Uint32 是否粉丝才可评论，0所有人可评论，1粉丝才可评论
        /// </summary>
        [JsonPropertyName("only_fans_can_comment")]
        public int OnlyFansCanComment { get; set; }
    }
}
