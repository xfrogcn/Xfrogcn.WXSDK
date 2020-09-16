using System;
using System.IO;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 流式应答
    /// </summary>
    public class WXStreamResponse : WXResponse
    {
        public Stream Stream { get; set; }

        [JsonPropertyName("video_url")]
        public string VideoUrl { get; set; }
    }
}
