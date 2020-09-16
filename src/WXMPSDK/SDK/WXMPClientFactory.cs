using System;
using System.Net.Http;

namespace WXMPSDK
{
    public class WXMPClientFactory
    {
        private readonly IHttpClientFactory _clientFactory;
        public WXMPClientFactory(
            IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public WXMPClient CreateWXClient(string appId)
        {
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException(nameof(appId));
            }

            HttpClient client = _clientFactory.CreateClient(appId);

            BasisServiceClient basisServiceClient = new BasisServiceClient(client);
            CustomServiceClient customServiceClient = new CustomServiceClient(client);
            TemplateServiceClient templateServiceClient = new TemplateServiceClient(client);
            MenuClient menuClient = new MenuClient(client);
            UserManagerClient umClient = new UserManagerClient(client);

            return new WXMPClient(
                basisServiceClient,
                customServiceClient,
                templateServiceClient,
                menuClient,
                umClient);
        }
    }
}
