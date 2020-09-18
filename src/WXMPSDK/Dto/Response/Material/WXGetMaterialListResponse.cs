using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取永久素材列表应答
    /// </summary>
    public class WXGetMaterialListResponse : WXResponse
    {
        /// <summary>
        /// 该类型的素材的总数
        /// </summary>
        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 本次调用获取的素材的数量
        /// </summary>
        [JsonPropertyName("item_count")]
        public int ItemCount { get; set; }

        [JsonPropertyName("item")]
        public List<WXMaterialListItem> Items { get; set; }
    }

    public class WXMaterialListItem
    {
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// 图文消息的具体内容，支持HTML标签，必须少于2万字符，小于1M，且此处会去除JS
        /// </summary>
        [JsonPropertyName("content")]
        public WXMaterialListNewsContent Content { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 图文页的URL，或者，当获取的列表是图片素材列表时，该字段是图片的URL
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// 这篇图文消息素材的最后更新时间
        /// </summary>
        [JsonPropertyName("update_time")]
        public long UpdateTime { get; set; }
    }

    public class WXMaterialListNewsContent
    {
        [JsonPropertyName("news_item")]
        public List<WXArticleItem> NewsItem { get; set; }
    }
}
