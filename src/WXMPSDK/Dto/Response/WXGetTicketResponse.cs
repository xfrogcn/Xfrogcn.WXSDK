using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXGetTicketResponse : WXResponse
    {
        [JsonPropertyName("ticket")]
        public string Ticket { get; set; }

        [JsonPropertyName("expires_in")]
        public long Expires { get; set; }
    }
}
