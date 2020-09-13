using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WXMPSDK;
using WXMPSDK.Dto;
using Xunit;

namespace WXMPSDKTests.SDK
{
    [Trait("", "Clients")]
    public class AccessTokenClientTest
    {
        [Fact(DisplayName = "获取访问令牌")]
        public async Task Test()
        {
            IServiceCollection sc = new ServiceCollection()
                .AddLogging()
                .AddTestLoggerProvider();

            HttpRequestMessage request = null;
            sc.AddHttpClient<AccessTokenClient>()
                .AddMockHttpMessageHandler()
                .AddMock("*", HttpMethod.Get, async (req, res) =>
                {
                    request = req;
                    await res.WriteObjectAsync(new WXAccessTokenResponse()
                    {
                        AccessToken = "111",
                        ExpiresIn = 7200
                    });
                });

            var sp = sc.BuildServiceProvider();
            
            var client = sp.GetRequiredService<AccessTokenClient>();
            var r = await  client.GetAccessTokenAsync("1", "s");

            Assert.Equal("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=1&secret=s", request.RequestUri.AbsoluteUri);
        }
    }
}
