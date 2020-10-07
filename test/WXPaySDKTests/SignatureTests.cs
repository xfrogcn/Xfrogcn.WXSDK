using System;
using WXPaySDK;
using Xunit;

namespace WXPaySDKTests
{
    [Trait("", "WXPaySDK")]
    public class SignatureTests
    {
        [Fact(DisplayName = "统一下单签名")]
        public void Test1()
        {
            WXPaySDK.Dto.WXUnifiedOrderRequest request = new WXPaySDK.Dto.WXUnifiedOrderRequest()
            {
                AppId = "wxd678efh567hg6787",
                MchId= "1230000109",
                DeviceInfo = "013467007045764",
                NonceStr = "5K8264ILTKCH16CQ2502SI8ZNMTM67VS",
                Sign="",
                SignType = "MD5",
                Body = "腾讯充值中心-QQ会员充值",
                Detail="A",
                Attach= "深圳分店",
                OutTradeNo = "20150806125346",
                TotalFee = 88,
                SpBillCreateIp = "123.12.12.123",
                TimeExpire = "20091227091010",
                TimeStart = "20091225091010",
                GoodsTag = "WXG",
                NotifyUrl = "http://www.weixin.qq.com/wxpay/pay.php",
                TradeType = "JSAPI",
                OpenId = "oUpF8uMuAJO_M2pxb1Q9zNjWeS6o",
                SceneInfo= ""
            };

            

            request.ComputeAndSetSign("TESTKEY");
            string xml = request.ToXml();
            Assert.Equal("075AF1552A96C977BE408921CE039D73", request.Sign);
        }
    }
}
