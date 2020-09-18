using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 新增其他类型永久素材
    /// </summary>
    public class WXAddMaterialResponse : WXResponse
    {
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
