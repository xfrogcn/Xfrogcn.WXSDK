using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 创建二维码应答
    /// </summary>
    public class WXCreateQrCodeResponse : WXResponse
    {
        [JsonPropertyName("ticket")]
        public string Ticket { get; set; }

        [JsonPropertyName("expire_seconds")]
        public long ExpireSeconds { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

    }
}
