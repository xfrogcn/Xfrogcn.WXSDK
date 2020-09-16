using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 创建标签应答
    /// </summary>
    public class WXCreateTagResponse : WXResponse
    {
        [JsonPropertyName("tag")]
        public WXTagInfo Tag { get; set; }
    }
}
