using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXResponse
    {
        //{"errcode":40013,"errmsg":"invalid appid"}

        [JsonPropertyName("errcode")]
        public int ErrCode { get; set; }

        [JsonPropertyName("errmsg")]
        public string ErrMsg { get; set; }

    }
}
