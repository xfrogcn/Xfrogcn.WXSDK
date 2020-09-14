using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WXMPSDK;
using WXMPSDK.Dto;
using Xunit;

namespace WXMPSDKTests.SDK
{
    [Trait("", "Clients")]
    public class MPSDKTest
    {
        [Fact(DisplayName = "模拟测试")]
        public async Task Test_Mock()
        {
            IServiceCollection sc = new ServiceCollection()
                .AddLogging()
                .AddTestLoggerProvider()
                .AddDistributedMemoryCache()
                .AddWXMPSDK("1", "1");

            HttpRequestMessage tokenRequest = null;
            sc.ConfigureTokenHttpClient()
                .AddMockHttpMessageHandler()
                .AddMock("*", HttpMethod.Get, async (req, res) =>
                {
                    tokenRequest = req;
                    await res.WriteObjectAsync(new WXAccessTokenResponse()
                    {
                        AccessToken = "1",
                        ExpiresIn = 60
                    });
                });

            HttpRequestMessage msgRequest = null;
            sc.AddHttpClient("1")
                .AddMockHttpMessageHandler()
                .AddMock("*", HttpMethod.Post, async (req, res) =>
                {
                    msgRequest = req;
                    await res.WriteObjectAsync(new WXResponse()
                    {
                        ErrCode = 0,
                        ErrMsg  = ""
                    });
                });

            var sp = sc.BuildServiceProvider();
            var factory = sp.GetRequiredService<WXMPClientFactory>();
            var wxClient = factory.CreateWXClient("1");

            var r = await wxClient.CustomServiceClient.SendMessage(new WXTextSendMessage()
            {
                Text = new WXRequestTextContent() {  Content = "HELLO"},
                ToUser = "1"
            });

            string str = await msgRequest.Content.ReadAsStringAsync();
            Assert.Equal("{\n  \"msgtype\": \"text\",\n  \"text\": {\n    \"content\": \"HELLO\"\n  },\n  \"touser\": \"1\"\n}", str);
        }

        [Fact(DisplayName = "实际调用")]
        public async Task Test1()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("./secrets/config.json")
                .Build();

            string appId = config["appId"];
            string appSecret = config["appSecret"];
            string openId = config["openId"];
            IServiceCollection sc = new ServiceCollection()
                .AddLogging()
                .AddTestLoggerProvider()
                .AddDistributedMemoryCache()
                .AddWXMPSDK(appId, appSecret);

            var sp = sc.BuildServiceProvider();
            var factory = sp.GetRequiredService<WXMPClientFactory>();
            var wxClient = factory.CreateWXClient(appId);

            var r = await  wxClient.CustomServiceClient.SendMessage(new WXTextSendMessage()
            {
                Text = new WXRequestTextContent() {  Content = "Hello World"},
                ToUser = openId
            });
        }


        [Fact(DisplayName = "模版消息")]
        public async Task Test2()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("./secrets/config.json")
                .Build();

            string appId = config["appId"];
            string appSecret = config["appSecret"];
            string openId = config["openId"];
            IServiceCollection sc = new ServiceCollection()
                .AddLogging()
                .AddTestLoggerProvider()
                .AddDistributedMemoryCache()
                .AddWXMPSDK(appId, appSecret);

            var sp = sc.BuildServiceProvider();
            var factory = sp.GetRequiredService<WXMPClientFactory>();
            var wxClient = factory.CreateWXClient(appId);

            var r = await wxClient.TemplateServiceClient
                .SendTemplateMessage(new WXTemplateMessage()
                {
                    ToUser = openId,
                    TemplateId = "ePYwrZle0Si2QSxBtLLmo8FFGG6vF_12-o1j_buIxLE",
                    Url = "https://www.baidu.com?keyword=hello",
                    Data = new System.Collections.Generic.Dictionary<string, TemplateMessageDataLine>()
                    {
                        {"orderNo", new TemplateMessageDataLine(){ Value = "DD1001", Color = "red"} },
                        {"money", new TemplateMessageDataLine( ){ Value = "123.00"} }
                    },
                    Color = "#173177"
                });
        }
    }
}
