using System;
using System.Net.Http;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    public class MenuClient
    {
        private HttpClient _client;
        public MenuClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<WXResponse> CreateMenu(WXMenuDefine menu)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/menu/create", menu);
        }
    }
}
