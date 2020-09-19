using System;
using WXMPSDK;
using Xfrogcn.AspNetCore.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.StaticFiles;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WXMPSDKCollectionServiceExtensions
    {
        /// <summary>
        /// 添加微信公众号SDK
        /// </summary>
        /// <param name="serviceDescriptors"></param>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static IServiceCollection AddWXMPSDK(this IServiceCollection serviceDescriptors, string appId, string secret, bool isDefault = true)
        {
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException(nameof(appId));
            }
            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            serviceDescriptors.TryAddSingleton<FileExtensionContentTypeProvider>();

            serviceDescriptors
                .AddClientTokenProvider(options =>
                {
                    options.AddClient(WXConstants.WXMPApiUrl.AbsoluteUri, appId, secret)
                        // 获取微信Token
                        .SetProcessor(async (client, tokenClient) =>
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
                        })
                        // 通过Url QueryString携带Accesstoken
                        .SetTokenSetter(SetTokenProcessor.QueryString)
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
