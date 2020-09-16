using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取标签下粉丝列表
    /// </summary>
    public class WXGetTagOpenIdResponse : WXResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("data")]
        public OpenIdListData Data { get; set; }

        [JsonPropertyName("next_openid")]
        public string NextOpenId { get; set; }
    }

    public class OpenIdListData
    {
        [JsonPropertyName("openid")]
        public List<string> OpenIds { get; set; }
    }

}
