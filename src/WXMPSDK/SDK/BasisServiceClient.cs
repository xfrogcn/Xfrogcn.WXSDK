using System;
using System.Net.Http;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    /// <summary>
    /// 基础支持服务
    /// </summary>
    public class BasisServiceClient
    {
        private readonly HttpClient _client;
        public BasisServiceClient(HttpClient client)
        {
            _client = client;
            if(_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        public async Task<WXIpListResponse> GetCallbackIpAsync()
        {
            var response = await _client.GetAsync<WXIpListResponse>("cgi-bin/getcallbackip");
            return response;
        }

        public async Task<WXIpListResponse> GetApiDomainIpAsync()
        {
            var response = await _client.GetAsync<WXIpListResponse>("cgi-bin/get_api_domain_ip");
            return response;
        }
    }
}
