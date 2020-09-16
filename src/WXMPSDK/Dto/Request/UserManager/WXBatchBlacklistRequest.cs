using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXBatchBlacklistRequest
    {
        [JsonPropertyName("openid_list")]
        public List<string> OpenIds { get; set; }
    }
}
