using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 标签
    /// </summary>
    public class WXTagInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
