using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 长连接转短链接
    /// </summary>
    public class WXShortUrlResponse : WXResponse
    {
        [JsonPropertyName("short_url")]
        public string ShortUrl { get; set; }
    }
}
