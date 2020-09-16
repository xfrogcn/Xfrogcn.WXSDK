using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    /// <summary>
    /// 素材管理
    /// </summary>
    public class MediaClient
    {
        private HttpClient _client;
        public MediaClient(HttpClient client)
        {
            _client = client;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        public async Task<WXMediaUploadResponse> UploadTempMaterial()
        {

        }
    }
}
