using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 标签应答信息
    /// </summary>
    public class WXTagResponseInfo : WXTagInfo
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
