using System;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 图文消息（点击跳转到图文消息页面） 
    /// </summary>
    public class WXMPNewsSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.MPNews;

        [JsonPropertyName("mpnews")]
        public WXRequestMediaContent MPNews { get; set; }
    }
}
