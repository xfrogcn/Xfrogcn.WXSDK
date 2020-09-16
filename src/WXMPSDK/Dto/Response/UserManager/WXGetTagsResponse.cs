using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取已创建标签列表
    /// </summary>
    public class WXGetTagsResponse : WXResponse
    {
        [JsonPropertyName("tags")]
        public List<WXTagResponseInfo> Tags { get; set; }
    }

    
}
