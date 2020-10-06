using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xfrogcn.AspNetCore.Extensions;

namespace WXMPSDK
{
    class WXCertificateProcessor : CertificateProcessor
    {
        readonly string _appId;
        public WXCertificateProcessor(string appId)
        {
            _appId = appId;
        }
        public override async Task<ClientCertificateToken> GetToken(ClientCertificateInfo clientInfo, IHttpClientFactory clientFactory)
        {
            var httpClient = clientFactory.CreateClient(_appId);

            TicketClient ticketClient = new TicketClient(httpClient);
            var r = await ticketClient.GetTicket("jsapi");
            if(r!=null && r.ErrCode == 0)
            {
                return new ClientCertificateToken()
                {
                    access_token = r.Ticket,
                    expires_in = r.Expires,
                    token_type = "ticket"
                };
            }

            return null;
        }
    }
}
