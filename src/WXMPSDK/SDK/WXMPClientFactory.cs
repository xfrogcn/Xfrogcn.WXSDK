using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Xfrogcn.AspNetCore.Extensions;

namespace WXMPSDK
{
    public class WXMPClientFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpClientFactory _clientFactory;
        public WXMPClientFactory(
            IServiceProvider serviceProvider,
            IHttpClientFactory clientFactory)
        {
            _serviceProvider = serviceProvider;
            _clientFactory = clientFactory;
        }

        public WXMPClient CreateWXClient(string appId)
        {
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException(nameof(appId));
            }

            HttpClient client = _clientFactory.CreateClient(appId);

            TicketClient ticketClient = new TicketClient(client);
            BasisServiceClient basisServiceClient = new BasisServiceClient(client);
            CustomServiceClient customServiceClient = new CustomServiceClient(client);
            TemplateServiceClient templateServiceClient = new TemplateServiceClient(client);
            MenuClient menuClient = new MenuClient(client);
            UserManagerClient umClient = new UserManagerClient(client);
            AccountManagerClient amClient = new AccountManagerClient(client);
            MaterialClient materialClient = new MaterialClient(client);

            var provider = _serviceProvider.GetRequiredService<IClientCertificateProvider>();
            AccessTokenManager tokenManger = new AccessTokenManager(appId, provider);

            return new WXMPClient(
                ticketClient,
                basisServiceClient,
                customServiceClient,
                templateServiceClient,
                menuClient,
                umClient,
                amClient,
                materialClient,
                tokenManger);
        }
    }
}
