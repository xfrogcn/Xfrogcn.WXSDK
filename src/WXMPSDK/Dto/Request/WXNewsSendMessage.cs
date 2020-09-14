using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 图文消息
    /// </summary>
    public class WXNewsSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.News;

        [JsonPropertyName("news")]
        public WXRequestNewsContent News { get; set; }
    }

    public class WXRequestNewsContent
    {
        [JsonPropertyName("articles")]
        public List<WXRequestArticlesItem> Articles { get; set; }
    }

    public class WXRequestArticlesItem
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("picurl")]
        public string PicUrl { get; set; }
    }
}
