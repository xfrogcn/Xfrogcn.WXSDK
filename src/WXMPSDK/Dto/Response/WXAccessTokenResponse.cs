using System;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXAccessTokenResponse : WXResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }
    }
}
