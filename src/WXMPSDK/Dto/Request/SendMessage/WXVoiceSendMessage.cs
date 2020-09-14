using System;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class WXVoiceSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.Voice;

        [JsonPropertyName("voice")]
        public WXRequestMediaContent Voice { get; set; }
    }
}
