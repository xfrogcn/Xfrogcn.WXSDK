using System;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class WXTextSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.Text;

        [JsonPropertyName("text")]
        public WXRequestTextContent Text { get; set; }
    }


    public class WXRequestTextContent
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
