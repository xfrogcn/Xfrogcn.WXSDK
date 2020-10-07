using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WXPaySDK.SDK
{
    public class WXPayClient
    {
        readonly HttpClient _client;
        readonly WXPayClientItem _ci;
        public WXPayClient(HttpClient httpClient, WXPayClientItem ci)
        {
            _client = httpClient;
            _ci = ci;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(WXPaySDKConstains.WXPAY_URL);
            }
        }

        public async Task<Dto.WXUnifiedOrderResponse> UnifiedOrder(Dto.WXUnifiedOrderRequest request)
        {
            request?.FillClientInfo(_ci);
            HttpResponseMessage response = await _client.PostAsync<HttpResponseMessage>("/pay/unifiedorder", request.ToXml());
            return await response.GetXmlObject<Dto.WXUnifiedOrderResponse>();
        }
    }
}
