using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xfrogcn.AspNetCore.Extensions;

namespace WXMPSDK
{
    public class AccessTokenManager
    {
        readonly string _appId;
        readonly IClientCertificateProvider _tokenProvider;
        public AccessTokenManager(string appId, IClientCertificateProvider tokenProvider)
        {
            _appId = appId;
            _tokenProvider = tokenProvider;
        }

        public async Task<string> GetAccessToken()
        {
            var manager = _tokenProvider.GetClientCertificateManager(_appId);
            return await manager.GetAccessToken();
        }

        public async Task<string> GetJSAPITicket()
        {
            var manager = _tokenProvider.GetClientCertificateManager($"JSAPI_{_appId}");
            return await manager.GetAccessToken();
        }
    }
}
