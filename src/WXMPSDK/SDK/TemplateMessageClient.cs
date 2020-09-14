using System;
using System.Net.Http;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    /// <summary>
    /// 模版消息
    /// </summary>
    public class TemplateServiceClient
    {
        private readonly HttpClient _client;
        public TemplateServiceClient(HttpClient client)
        {
            _client = client;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        /// <summary>
        /// 发送模版消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<WXMessageResponse> SendTemplateMessage(WXTemplateMessage msg)
        {
            return await _client.PostAsync<WXMessageResponse>("cgi-bin/message/template/send", msg);
        }
    }
}
