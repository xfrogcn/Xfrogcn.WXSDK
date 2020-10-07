using Microsoft.Extensions.DependencyInjection.Extensions;
using WXPaySDK;
using WXPaySDK.SDK;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WXPaySDKServiceCollectionExtensions
    {
        public static IHttpClientBuilder  AddWXPaySDK(this IServiceCollection serviceDescriptors, string name, string appId, string mchId, string key)
        {
            serviceDescriptors.TryAddSingleton<WXPayClientFactory>();
            serviceDescriptors.Configure<WXPayClientOptions>(options =>
            {
                options.AddClient(name??string.Empty, appId, mchId, key);
            });
            if (string.IsNullOrEmpty(name))
            {
                //默认
                serviceDescriptors.AddScoped<WXPayClient>((sp) =>
                {
                    var factory = sp.GetRequiredService<WXPayClientFactory>();
                    return factory.GetClient(string.Empty);
                });
            }
            return serviceDescriptors.AddHttpClient(WXPayClientFactory.GetHttpClientName(name, appId, mchId), c =>
            {
                c.BaseAddress = new System.Uri(WXPaySDKConstains.WXPAY_URL);
            });

        }
    }
}
