using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 修改图文素材
    /// </summary>
    public class WXUpdateNewsRequest
    {
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("articles")]
        public WXArticleItem Articles { get; set; }
    }

}
