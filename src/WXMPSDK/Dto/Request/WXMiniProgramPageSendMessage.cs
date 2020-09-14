using System;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 小程序卡片
    /// </summary>
    public class WXMiniProgramPageSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.MiniProgramPage;

        [JsonPropertyName("miniprogrampage")]
        public WXRequestMiniProgramContent MiniProgramPage { get; set; }
    }


    public class WXRequestMiniProgramContent
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }

        [JsonPropertyName("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }
}
