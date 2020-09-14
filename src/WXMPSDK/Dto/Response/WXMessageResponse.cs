using System;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXMessageResponse : WXResponse
    {
        [JsonPropertyName("msgid")]
        public long MsgId { get; set; }
    }
}
