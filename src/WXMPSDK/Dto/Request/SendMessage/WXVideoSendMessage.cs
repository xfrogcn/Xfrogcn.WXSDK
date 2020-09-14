using System;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 视频消息
    /// </summary>
    public class WXVideoSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.Video;

        [JsonPropertyName("video")]
        public WXRequestVideoContent Video { get; set; }
    }

    public class WXRequestVideoContent: WXRequestMediaContent
    {
        [JsonPropertyName("thumb_media_id")]
        public string ThumbMediaId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
