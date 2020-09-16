using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取用户身上的标签列表应答
    /// </summary>
    public class WXGetUserTagListResponse : WXResponse
    {
        [JsonPropertyName("tagid_list")]
        public List<int> TagList { get; set; }
    }


}
