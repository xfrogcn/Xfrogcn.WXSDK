using System;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 音乐消息
    /// </summary>
    public class WXMusicSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.Music;

        [JsonPropertyName("music")]
        public WXRequestMusicContent Music { get; set; }
    }

    public class WXRequestMusicContent 
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("musicurl")]
        public string MusicUrl { get; set; }

        [JsonPropertyName("hqmusicurl")]
        public string HQMusicUrl { get; set; }

        [JsonPropertyName("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }
}
