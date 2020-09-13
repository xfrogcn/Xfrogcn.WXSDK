using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXIpListResponse : WXResponse
    {
        [JsonPropertyName("ip_list")]
        public IList<string> IpList { get; set; }
    }
}
