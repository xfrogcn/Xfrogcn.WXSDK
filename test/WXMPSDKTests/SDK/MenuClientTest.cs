using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WXMPSDK;
using WXMPSDK.Dto;
using Xunit;

namespace WXMPSDKTests.SDK
{
    [Trait("", "Clients")]
    public class MenuClientTest
    {

        [Fact(DisplayName = "创建菜单请求消息")]
        public async Task Test1()
        {
            IServiceCollection sc = new ServiceCollection()
                .AddLogging(lb =>
                {
                    lb.SetMinimumLevel(LogLevel.Trace);
                })
                .AddTestLoggerProvider()
                .AddDistributedMemoryCache()
                .AddWXMPSDK("1", "1");

            HttpRequestMessage request = null;
            sc.ConfigureTokenHttpClient()
                .AddMockHttpMessageHandler()
                .AddMock("*", HttpMethod.Get, new WXAccessTokenResponse()
                {
                    AccessToken = "11",
                    ExpiresIn = 7200
                });
            sc.AddHttpClient("1")
                .AddMockHttpMessageHandler()
                .AddMock("*", HttpMethod.Post, async (req, res) =>
                {
                    request = req;
                });


            var sp = sc.BuildServiceProvider();
            var factory = sp.GetRequiredService<WXMPClientFactory>();
            var wxClient = factory.CreateWXClient("1");

            var r = await wxClient.MenuClient.CreateMenu(new WXMPSDK.Dto.WXMenuDefine()
            {
                Buttons = new List<WXMPSDK.Dto.MenuItem>()
                {
                    new MenuViewButton(){ Name = "百度", Url = "https://www.baidu.com"},
                    new MenuScanCodePushButton(){ Name = "扫一扫", Key ="IDX_MENU_1"}
                }
            });
            string requestStr = await request.Content.ReadAsStringAsync();

        }

        [Fact(DisplayName = "创建菜单")]
        public async Task Test()
        {
            var config = new ConfigurationBuilder()
    .AddJsonFile("./secrets/config.json")
    .Build();

            string appId = config["appId"];
            string appSecret = config["appSecret"];
            string openId = config["openId"];
            IServiceCollection sc = new ServiceCollection()
                .AddLogging(lb=>
                {
                    lb.SetMinimumLevel(LogLevel.Trace);
                })
                .AddTestLoggerProvider()
                .AddDistributedMemoryCache()
                .AddWXMPSDK(appId, appSecret);

            var sp = sc.BuildServiceProvider();
            var factory = sp.GetRequiredService<WXMPClientFactory>();
            var wxClient = factory.CreateWXClient(appId);

            var r = await wxClient.MenuClient.CreateMenu(new WXMPSDK.Dto.WXMenuDefine()
            {
                Buttons = new List<WXMPSDK.Dto.MenuItem>()
                {
                    new MenuViewButton(){ Name = "百度", Url = "https://www.baidu.com"},
                    new MenuScanCodePushButton(){ Name = "扫一扫", Key ="IDX_MENU_1"}
                }
            });

            var log= sp.GetTestLogContent();
        }
    }
}
