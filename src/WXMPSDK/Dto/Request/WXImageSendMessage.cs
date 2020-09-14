using System;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class WXImageSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.Image;

        [JsonPropertyName("image")]
        public WXRequestMediaContent Image { get; set; }
    }
}
