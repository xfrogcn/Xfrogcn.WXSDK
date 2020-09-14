using System;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 客服信息
    /// </summary>
    public class WXCustomInfo
    {
        [JsonPropertyName("kf_account")]

        public string KfAccount { get; set; }

        [JsonPropertyName("nickname")]
        public string NickName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
