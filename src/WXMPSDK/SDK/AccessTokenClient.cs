using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    public class AccessTokenClient
    {
        private readonly HttpClient _client = null;
        public AccessTokenClient(HttpClient client)
        {
            _client = client;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        public async Task<WXAccessTokenResponse> GetAccessTokenAsync(string appid, string secret)
        {
            NameValueCollection query = new NameValueCollection()
            {
                { "grant_type", "client_credential" },
                { "appid", appid },
                { "secret", secret }
            };

            WXAccessTokenResponse response = await _client.GetAsync<WXAccessTokenResponse>("cgi-bin/token", query);

            return response;
        }
    }
}
