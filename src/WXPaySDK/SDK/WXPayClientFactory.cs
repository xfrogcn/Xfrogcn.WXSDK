using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace WXPaySDK.SDK
{
    public class WXPayClientFactory
    {
        readonly WXPayClientOptions _options;
        readonly IHttpClientFactory _clientFactory;
        public WXPayClientFactory(
            IOptions<WXPayClientOptions> options,
            IHttpClientFactory clientFactory
            )
        {
            _options = options.Value;
            _clientFactory = clientFactory;
        }


        public WXPayClient GetClient(string name)
        {
            var clientInfo = _options.Clients.FirstOrDefault(c => c.Name == (name??string.Empty));
            if(clientInfo == null)
            {
                throw new NotSupportedException("不存在");
            }

            HttpClient client = _clientFactory.CreateClient(GetHttpClientName(clientInfo.Name, clientInfo.AppId, clientInfo.MchId));

            return new WXPayClient(client, clientInfo);
        }

        public static string GetHttpClientName(string name, string appId, string mchId)
        {
            return $"WXPAY_{name??string.Empty}-{appId}-{mchId}";
        }
    }
}
