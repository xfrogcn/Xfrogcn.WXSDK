using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 批量获取用户信息请求
    /// </summary>
    public class WXBatchGetUserInfoRequest
    {
        [JsonPropertyName("user_list")]
        public List<WXUserRequestItem> UserList { get; set; }

    }

    public class WXUserRequestItem
    {
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }
    }
}
