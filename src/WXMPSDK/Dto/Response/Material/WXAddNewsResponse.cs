using System;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 新增图文素材应答
    /// </summary>
    public class WXAddNewsResponse : WXResponse
    {
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
    }
}
