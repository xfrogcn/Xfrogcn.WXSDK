using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 文章消息菜单
    /// </summary>
    public class MenuNewsMessageButton: MenuValueButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.News;

        [JsonPropertyName("news_info")]
        public MenuNewsInfo NewsInfo { get; set; }
    }

    public class MenuNewsInfo
    {
        /// <summary>
        /// 图文列表
        /// </summary>
        [JsonPropertyName("list")]
        public List<MenuNewsItem> List { get; set; }
    }

    public class MenuNewsItem
    {
        /// <summary>
        /// 图文消息的标题
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [JsonPropertyName("author")]
        public string Author { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [JsonPropertyName("digest")]
        public string Digest { get; set; }
        /// <summary>
        /// 是否显示封面，0为不显示，1为显示
        /// </summary>
        [JsonPropertyName("show_cover")]
        public int ShowCover { get; set; }
        /// <summary>
        /// 封面图片的URL
        /// </summary>
        [JsonPropertyName("cover_url")]
        public string CoverUrl { get; set; }
        /// <summary>
        /// 正文的URL
        /// </summary>
        [JsonPropertyName("content_url")]
        public string ContentUrl { get; set; }
        /// <summary>
        /// 原文的URL，若置空则无查看原文入口
        /// </summary>
        [JsonPropertyName("source_url")]
        public string SourceUrl { get; set; }
    }
}
