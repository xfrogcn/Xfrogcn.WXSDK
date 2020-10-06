using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    public class TicketClient
    {
        private readonly HttpClient _client = null;
        public TicketClient(HttpClient client)
        {
            _client = client;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        public async Task<WXGetTicketResponse> GetTicket(string type)
        {
            NameValueCollection qs = new NameValueCollection()
            {
                {"type", type }
            };

            return await _client.GetAsync<WXGetTicketResponse>("/cgi-bin/ticket/getticket", qs);
        }
    }
}
