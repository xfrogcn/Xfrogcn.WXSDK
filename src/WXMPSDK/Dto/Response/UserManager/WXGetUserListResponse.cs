using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取帐号的关注者列表
    /// </summary>
    public class WXGetUserListResponse : WXGetTagOpenIdResponse
    {
        [JsonPropertyName("total")]
        public long Total { get; set; }
    }
}
