using System;
using WXMPSDK;
using Xfrogcn.AspNetCore.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http;
using System.Threading.Tasks;
using WXMPSDK.Dto;
using System.Linq;
using System.IO;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WXMPSDKCollectionServiceExtensions
    {
        readonly static int[] invalidTokenErrCodes = new int[]
        {
            40001, 40002, 40014, 42001, 42007
        };

        readonly static string[] checkMediaTypes = new string[]
        {
            "json", "text", "xml"
        };

        /// <summary>
        /// 添加微信公众号SDK
        /// </summary>
        /// <param name="serviceDescriptors"></param>
        /// <param name="appId">应用ID</param>
        /// <param name="secret">应用密钥</param>
        /// <param name="isDefault">是否默认，指定默认后，可直接通过WXMPClient从ServiceProvider获取，而无需通过factory</param>
        /// <param name="token">固定token，适合于在调试时，指定固定token</param>
        /// <param name="wxTokenGetter">微信token获取器，如果不直接从微信获取token则可以指定自己的token获取策略</param>
        /// <returns></returns>
        public static IServiceCollection AddWXMPSDK(
            this IServiceCollection serviceDescriptors,
            string appId,
            string secret,
            bool isDefault = true,
            string token = null,
            Func<ClientCertificateInfo, HttpClient, Task<ClientCertificateToken>> wxTokenGetter = null)
        {
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException(nameof(appId));
            }
            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            Func<ClientCertificateInfo, HttpClient, Task<ClientCertificateToken>> getter = wxTokenGetter;
            if (!string.IsNullOrEmpty(token))
            {
                getter = (c, h) =>
                {
                    return Task.FromResult(new ClientCertificateToken()
                    {
                        access_token = token,
                        expires_in = 7200
                    });
                };
            }
            if (getter == null)
            {
                getter = async (client, tokenClient) =>
                {
                    AccessTokenClient atc = new AccessTokenClient(tokenClient);
                    var r = await atc.GetAccessTokenAsync(client.ClientID, client.ClientSecret);
                    if (!string.IsNullOrEmpty(r.AccessToken))
                    {
                        return new Xfrogcn.AspNetCore.Extensions.ClientCertificateToken()
                        {
                            access_token = r.AccessToken,
                            expires_in = r.ExpiresIn
                        };
                    }
                    return null;
                };
            }

            serviceDescriptors.TryAddSingleton<FileExtensionContentTypeProvider>();

            serviceDescriptors
                .AddClientTokenProvider(options =>
                {
                    options.AddClient(WXConstants.WXMPApiUrl.AbsoluteUri, appId, secret)
                        // 获取微信Token
                        .SetProcessor(getter)
                        // 通过Url QueryString携带Accesstoken
                        .SetTokenSetter(SetTokenProcessor.QueryString)
                        // 应答检查
                        .SetResponseChecker(async (response) =>
                        {
                            try
                            {
                                if(checkMediaTypes.Contains( response.Content.Headers.ContentType.MediaType)
                                    && response.Content.Headers.ContentLength <= 1024 * 2)
                                {
                                    var r = await response.GetObjectAsync<WXResponse>(true);
                                    if (r == null || invalidTokenErrCodes.Contains(r.ErrCode))
                                    {
                                        throw new UnauthorizedAccessException("令牌非法");
                                    }
                                }
                            }
                            finally
                            {

                            }
                        })
                        // 使用分布式缓存存储Token
                        .SetTokenCacheManager(TokenCacheManager.DistributedCacheFactory);
                });

            // 微信Token处理器
            serviceDescriptors
                .AddHttpClient(appId, client =>
                {
                    client.BaseAddress = WXConstants.WXMPApiUrl;
                })
                .AddTokenMessageHandler(appId);

            serviceDescriptors.TryAddSingleton<WXMPClientFactory>();

            if (isDefault)
            {
                serviceDescriptors.TryAddScoped((sp) =>
                {
                    WXMPClientFactory factory = sp.GetRequiredService<WXMPClientFactory>();
                    return factory.CreateWXClient(appId);
                });
            }

            return serviceDescriptors;
        }

    }
}
