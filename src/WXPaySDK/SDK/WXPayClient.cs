using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WXPaySDK.Dto;
using Xfrogcn.AspNetCore.Extensions;

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

        public async Task<Dto.WXOrderQueryResponse> QueryOrder(Dto.WXOrderQueryRequest request)
        {
            request?.FillClientInfo(_ci);
            HttpResponseMessage response = await _client.PostAsync<HttpResponseMessage>("/pay/orderquery", request.ToXml());
            return await response.GetXmlObject<Dto.WXOrderQueryResponse>();
        }

        public async Task<Dto.WXCloseOrderResponse> CloseOrder(string outTradeNo)
        {
            Dto.WXCloseOrderRequest request = new WXCloseOrderRequest()
            {
                OutTradeNo = outTradeNo,
                NonceStr = StringExtensions.RandomString(12)
            };
            request.FillClientInfo(_ci);
            HttpResponseMessage response = await _client.PostAsync<HttpResponseMessage>("/pay/closeorder", request.ToXml());
            return await response.GetXmlObject<Dto.WXCloseOrderResponse>();
        }

        public async Task<Dto.WXRefundResponse> Refund(Dto.WXRefundRequest request)
        {
            request?.FillClientInfo(_ci);
            HttpResponseMessage response = await _client.PostAsync<HttpResponseMessage>("/pay/refund", request.ToXml());
            return await response.GetXmlObject<Dto.WXRefundResponse>();
        }

        public bool ValidSignature(WXPayBase msg)
        {
            return msg.ValidSignature(_ci.Key);
        }
    }
}
