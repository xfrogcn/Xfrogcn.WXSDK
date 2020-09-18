using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取永久素材详情
    /// </summary>
    public class WXGetMaterialResponse : WXResponse
    {
        /// <summary>
        /// 图文信息
        /// </summary>
        [JsonPropertyName("news_item")]
        public  List<WXArticleItem> NewsItems { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("down_url")]
        public string DownUrl { get; set; }

        /// <summary>
        /// 当素材类型不是图文或视频时，返回素材的下载流
        /// </summary>
        [JsonIgnore]
        public Stream Stream { get; set; }
    }
}
