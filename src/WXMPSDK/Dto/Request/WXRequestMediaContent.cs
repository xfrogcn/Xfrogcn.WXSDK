using System;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXRequestMediaContent
    {
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
    }
}
