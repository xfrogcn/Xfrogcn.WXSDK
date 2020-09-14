using System;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 卡券
    /// </summary>
    public class WXCardSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.WXCard;

        [JsonPropertyName("wxcard")]
        public WXRequestCardContent WXCard { get; set; }
    }


    public class WXRequestCardContent
    {
        [JsonPropertyName("card_id")]
        public string CardId { get; set; }
    }
}
