using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取用户详情列表
    /// </summary>
    public class WXGetUserInfoListResponse : WXResponse
    {
        [JsonPropertyName("user_info_list")]
        public List<WXUserInfo> UserList { get; set; }
    }
}
