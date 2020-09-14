using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 模版消息
    /// </summary>
    public class WXTemplateMessage
    {
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }

        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("miniprogram")]
        public TemplateMiniProgramInfo MiniProgram { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, TemplateMessageDataLine> Data { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }
    }

    public class TemplateMiniProgramInfo
    {
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }
    }

    public class TemplateMessageDataLine
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
