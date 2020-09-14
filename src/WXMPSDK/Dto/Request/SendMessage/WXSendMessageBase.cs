using System;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXSendMessageBase
    {
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }

        [JsonPropertyName("msgtype")]
        public virtual string MsgType { get; } = "";

        [JsonPropertyName("customservice")]
        public SendMessageCustomServiceInfo CustomService { get; set; }
    }


    public class SendMessageCustomServiceInfo
    {
        [JsonPropertyName("kf_account")]
        public string KfAccount { get; set; }
    }
}
