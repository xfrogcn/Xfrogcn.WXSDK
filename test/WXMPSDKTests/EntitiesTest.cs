using System;
using WXMPSDK.Entities;
using Xunit;

namespace WXMPSDKTests
{
    [Trait("", "WXMPSDK")]
    public class EntitiesTest
    {
        [Fact(DisplayName = "序列化-回复文本消息")]
        public void Se_Test_1()
        {
            WXTextReplyMessage txtMsg = new WXTextReplyMessage()
            {
                ToUserName = "To",
                FromUserName = "OpenId",
                Content = "HELLO",
                CreateTime = 123
            };
            string xml = txtMsg.ToXml();


            Assert.Equal("<xml><ToUserName>To</ToUserName><FromUserName>OpenId</FromUserName><CreateTime>123</CreateTime><MsgType>text</MsgType><Content>HELLO</Content></xml>",
                xml);
        }

        [Fact(DisplayName = "序列化-回复图片消息")]
        public void Se_Test_2()
        {
            WXImageReplyMessage txtMsg = new WXImageReplyMessage()
            {
                ToUserName = "To",
                FromUserName = "OpenId",
                CreateTime = 123,
                Image = new ImageMessageContent()
                {
                    MediaId = "123"
                }
            };
            string xml = txtMsg.ToXml();


            Assert.Equal("<xml><ToUserName>To</ToUserName><FromUserName>OpenId</FromUserName><CreateTime>123</CreateTime><MsgType>image</MsgType><Image><MediaId>123</MediaId></Image></xml>",
                xml);
        }

        [Fact(DisplayName = "反序列化-关注/取消关注事件")]
        public void De_Test_1()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[FromUser]]></FromUserName>
  <CreateTime>123456789</CreateTime>
  <MsgType><![CDATA[event]]></MsgType>
  <Event><![CDATA[subscribe]]></Event>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXSubscribeEventMessage;
            Assert.NotNull(msg);
            Assert.Equal(WXMsgEventNames.Subscribe, msg.Event);
            Assert.Equal(123456789, msg.CreateTime);
            Assert.Equal(WXMsgTypes.Event, msg.MsgType);
            Assert.Equal("toUser", msg.ToUserName);
            Assert.Equal("FromUser", msg.FromUserName);

            xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[FromUser]]></FromUserName>
  <CreateTime>123456789</CreateTime>
  <MsgType><![CDATA[event]]></MsgType>
  <Event><![CDATA[unsubscribe]]></Event>
</xml>";
            var msg2 = WXMessageBase.FromXml(xml) as WXUnsubscribeEventMessage;
            Assert.NotNull(msg2);

            xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[FromUser]]></FromUserName>
  <CreateTime>123456789</CreateTime>
  <MsgType><![CDATA[event]]></MsgType>
  <Event><![CDATA[subscribe]]></Event>
  <EventKey><![CDATA[qrscene_123123]]></EventKey>
  <Ticket><![CDATA[TICKET]]></Ticket>
</xml>";
            var msg3 = WXMessageBase.FromXml(xml) as WXSubscribeEventMessage;
            Assert.NotNull(msg3);
            Assert.Equal("TICKET", msg3.Ticket);
            Assert.Equal("qrscene_123123", msg3.EventKey);

            xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[FromUser]]></FromUserName>
  <CreateTime>123456789</CreateTime>
  <MsgType><![CDATA[event]]></MsgType>
  <Event><![CDATA[SCAN]]></Event>
  <EventKey><![CDATA[SCENE_VALUE]]></EventKey>
  <Ticket><![CDATA[TICKET]]></Ticket>
</xml>";
            var msg4 = WXMessageBase.FromXml(xml) as WXScanEventMessage;
            Assert.NotNull(msg4);
            Assert.Equal("TICKET", msg4.Ticket);
            Assert.Equal("SCENE_VALUE", msg4.EventKey);
        }

        [Fact(DisplayName = "反序列化-上报地理位置事件")]
        public void De_Test_2()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>123456789</CreateTime>
  <MsgType><![CDATA[event]]></MsgType>
  <Event><![CDATA[LOCATION]]></Event>
  <Latitude>23.137466</Latitude>
  <Longitude>113.352425</Longitude>
  <Precision>119.385040</Precision>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXLocationEventMessage;
            Assert.NotNull(msg);
            Assert.Equal(23.137466, msg.Latitude);
            Assert.Equal(113.352425, msg.Longitude);
            Assert.Equal(119.385040, msg.Precision);

        }

        [Fact(DisplayName = "反序列化-自定义菜单事件")]
        public void De_Test_3()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[FromUser]]></FromUserName>
  <CreateTime>123456789</CreateTime>
  <MsgType><![CDATA[event]]></MsgType>
  <Event><![CDATA[CLICK]]></Event>
  <EventKey><![CDATA[EVENTKEY]]></EventKey>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXClickEventMessage;
            Assert.NotNull(msg);
            Assert.Equal("EVENTKEY", msg.EventKey);
        }

        [Fact(DisplayName = "反序列化-点击菜单跳转链接")]
        public void De_Test_4()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[FromUser]]></FromUserName>
  <CreateTime>123456789</CreateTime>
  <MsgType><![CDATA[event]]></MsgType>
  <Event><![CDATA[VIEW]]></Event>
  <EventKey><![CDATA[www.qq.com]]></EventKey>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXViewEventMessage;
            Assert.NotNull(msg);
            Assert.Equal("www.qq.com", msg.EventKey);
        }

        [Fact(DisplayName = "反序列化-文本消息")]
        public void De_Test_5()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>1348831860</CreateTime>
  <MsgType><![CDATA[text]]></MsgType>
  <Content><![CDATA[this is a test]]></Content>
  <MsgId>1234567890123456</MsgId>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXTextReceiveMessage;
            Assert.NotNull(msg);
            Assert.Equal("1234567890123456", msg.MsgId);
            Assert.Equal("this is a test", msg.Content);
            Assert.Equal("text", msg.MsgType);
        }

        [Fact(DisplayName = "反序列化-图片消息")]
        public void De_Test_6()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>1348831860</CreateTime>
  <MsgType><![CDATA[image]]></MsgType>
  <PicUrl><![CDATA[this is a url]]></PicUrl>
  <MediaId><![CDATA[media_id]]></MediaId>
  <MsgId>1234567890123456</MsgId>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXImageReceiveMessage;
            Assert.NotNull(msg);
            Assert.Equal("1234567890123456", msg.MsgId);
            Assert.Equal("media_id", msg.MediaId);
            Assert.Equal("this is a url", msg.PicUrl);
        }

        [Fact(DisplayName = "反序列化-语音消息")]
        public void De_Test_7()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>1357290913</CreateTime>
  <MsgType><![CDATA[voice]]></MsgType>
  <MediaId><![CDATA[media_id]]></MediaId>
  <Format><![CDATA[Format]]></Format>
  <MsgId>1234567890123456</MsgId>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXVoiceReceiveMessage;
            Assert.NotNull(msg);
            Assert.Equal("1234567890123456", msg.MsgId);
            Assert.Equal("media_id", msg.MediaId);
            Assert.Equal("Format", msg.Format);

            xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>1357290913</CreateTime>
  <MsgType><![CDATA[voice]]></MsgType>
  <MediaId><![CDATA[media_id]]></MediaId>
  <Format><![CDATA[Format]]></Format>
  <Recognition><![CDATA[腾讯微信团队]]></Recognition>
  <MsgId>1234567890123456</MsgId>
</xml>";
            msg = WXMessageBase.FromXml(xml) as WXVoiceReceiveMessage;
            Assert.Equal("腾讯微信团队", msg.Recognition);

        }

        [Fact(DisplayName = "反序列化-视频消息")]
        public void De_Test_8()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>1357290913</CreateTime>
  <MsgType><![CDATA[video]]></MsgType>
  <MediaId><![CDATA[media_id]]></MediaId>
  <ThumbMediaId><![CDATA[thumb_media_id]]></ThumbMediaId>
  <MsgId>1234567890123456</MsgId>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXVideoReceiveMessage;
            Assert.NotNull(msg);
            Assert.Equal("1234567890123456", msg.MsgId);
            Assert.Equal("media_id", msg.MediaId);
            Assert.Equal("thumb_media_id", msg.ThumbMediaId);
        }

        [Fact(DisplayName = "反序列化-小视频消息")]
        public void De_Test_9()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>1357290913</CreateTime>
  <MsgType><![CDATA[shortvideo]]></MsgType>
  <MediaId><![CDATA[media_id]]></MediaId>
  <ThumbMediaId><![CDATA[thumb_media_id]]></ThumbMediaId>
  <MsgId>1234567890123456</MsgId>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXShortVideoReceiveMessage;
            Assert.NotNull(msg);
            Assert.Equal("1234567890123456", msg.MsgId);
            Assert.Equal("media_id", msg.MediaId);
            Assert.Equal("shortvideo", msg.MsgType);
            Assert.Equal("thumb_media_id", msg.ThumbMediaId);
        }

        [Fact(DisplayName = "反序列化-地理位置消息")]
        public void De_Test_10()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>1351776360</CreateTime>
  <MsgType><![CDATA[location]]></MsgType>
  <Location_X>23.134521</Location_X>
  <Location_Y>113.358803</Location_Y>
  <Scale>20</Scale>
  <Label><![CDATA[位置信息]]></Label>
  <MsgId>1234567890123456</MsgId>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXLocationReceiveMessage;
            Assert.NotNull(msg);
            Assert.Equal("1234567890123456", msg.MsgId);
            Assert.Equal("位置信息", msg.Label);
            Assert.Equal(23.134521, msg.Location_X);
            Assert.Equal(113.358803, msg.Location_Y);
            Assert.Equal(20, msg.Scale);
        }

        [Fact(DisplayName = "反序列化-链接消息")]
        public void De_Test_11()
        {
            string xml = @"<xml>
  <ToUserName><![CDATA[toUser]]></ToUserName>
  <FromUserName><![CDATA[fromUser]]></FromUserName>
  <CreateTime>1351776360</CreateTime>
  <MsgType><![CDATA[link]]></MsgType>
  <Title><![CDATA[公众平台官网链接]]></Title>
  <Description><![CDATA[公众平台官网链接]]></Description>
  <Url><![CDATA[url]]></Url>
  <MsgId>1234567890123456</MsgId>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXLinkReceiveMessage;
            Assert.NotNull(msg);
            Assert.Equal("1234567890123456", msg.MsgId);
            Assert.Equal("url", msg.Url);
            Assert.Equal("公众平台官网链接", msg.Title);
            Assert.Equal("公众平台官网链接", msg.Description);
        }

        [Fact(DisplayName = "反序列化-扫码推事件的事件推送")]
        public void De_Test_12()
        {
            string xml = @"<xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
<FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
<CreateTime>1408090502</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[scancode_push]]></Event>
<EventKey><![CDATA[6]]></EventKey>
<ScanCodeInfo><ScanType><![CDATA[qrcode]]></ScanType>
<ScanResult><![CDATA[1]]></ScanResult>
</ScanCodeInfo>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXScanCodePushEventMessage;
            Assert.NotNull(msg);
            Assert.NotNull(msg.ScanCodeInfo);
            Assert.Equal("6", msg.EventKey);

            Assert.Equal("qrcode", msg.ScanCodeInfo.ScanType);
            Assert.Equal("1", msg.ScanCodeInfo.ScanResult);
        }

        [Fact(DisplayName = "反序列化-扫码推事件且弹出“消息接收中”")]
        public void De_Test_13()
        {
            string xml = @"<xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
<FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
<CreateTime>1408090606</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[scancode_waitmsg]]></Event>
<EventKey><![CDATA[6]]></EventKey>
<ScanCodeInfo><ScanType><![CDATA[qrcode]]></ScanType>
<ScanResult><![CDATA[2]]></ScanResult>
</ScanCodeInfo>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXScanCodeWaitMsgEventMessage;
            Assert.NotNull(msg);
            Assert.NotNull(msg.ScanCodeInfo);
            Assert.Equal("6", msg.EventKey);

            Assert.Equal("qrcode", msg.ScanCodeInfo.ScanType);
            Assert.Equal("2", msg.ScanCodeInfo.ScanResult);
        }

        [Fact(DisplayName = "反序列化-弹出系统拍照发图的事件推送")]
        public void De_Test_14()
        {
            string xml = @"<xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
<FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
<CreateTime>1408090651</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[pic_sysphoto]]></Event>
<EventKey><![CDATA[6]]></EventKey>
<SendPicsInfo><Count>1</Count>
<PicList><item><PicMd5Sum><![CDATA[1b5f7c23b5bf75682a53e7b6d163e185]]></PicMd5Sum>
</item>
</PicList>
</SendPicsInfo>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXPicSysPhotoEventMessage;
            Assert.NotNull(msg);
            Assert.NotNull(msg.SendPicsInfo);
            Assert.Equal("6", msg.EventKey);
            Assert.Single(msg.SendPicsInfo.PicList);

            Assert.Equal(1, msg.SendPicsInfo.Count);
            Assert.Equal("1b5f7c23b5bf75682a53e7b6d163e185", msg.SendPicsInfo.PicList[0].PicMd5Sum);
        }

        [Fact(DisplayName = "反序列化-弹出拍照或者相册发图的事件推送")]
        public void De_Test_15()
        {
            string xml = @"<xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
<FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
<CreateTime>1408090816</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[pic_photo_or_album]]></Event>
<EventKey><![CDATA[6]]></EventKey>
<SendPicsInfo><Count>1</Count>
<PicList><item><PicMd5Sum><![CDATA[5a75aaca956d97be686719218f275c6b]]></PicMd5Sum>
</item>
</PicList>
</SendPicsInfo>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXPicPhotoOrAlbumEventMessage;
            Assert.NotNull(msg);
            Assert.NotNull(msg.SendPicsInfo);
            Assert.Equal("6", msg.EventKey);
            Assert.Single(msg.SendPicsInfo.PicList);

            Assert.Equal(1, msg.SendPicsInfo.Count);
            Assert.Equal("5a75aaca956d97be686719218f275c6b", msg.SendPicsInfo.PicList[0].PicMd5Sum);
        }

        [Fact(DisplayName = "反序列化-弹出微信相册发图器的事件推送")]
        public void De_Test_16()
        {
            string xml = @"<xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
<FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
<CreateTime>1408090816</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[pic_weixin]]></Event>
<EventKey><![CDATA[6]]></EventKey>
<SendPicsInfo><Count>1</Count>
<PicList><item><PicMd5Sum><![CDATA[5a75aaca956d97be686719218f275c6b]]></PicMd5Sum>
</item>
</PicList>
</SendPicsInfo>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXPicWeiXinEventMessage;
            Assert.NotNull(msg);
            Assert.NotNull(msg.SendPicsInfo);
            Assert.Equal("6", msg.EventKey);
            Assert.Single(msg.SendPicsInfo.PicList);

            Assert.Equal(1, msg.SendPicsInfo.Count);
            Assert.Equal("5a75aaca956d97be686719218f275c6b", msg.SendPicsInfo.PicList[0].PicMd5Sum);
        }

        [Fact(DisplayName = "反序列化-弹出地理位置选择器的事件推送")]
        public void De_Test_17()
        {
            string xml = @"<xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
<FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
<CreateTime>1408091189</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[location_select]]></Event>
<EventKey><![CDATA[6]]></EventKey>
<SendLocationInfo><Location_X><![CDATA[23]]></Location_X>
<Location_Y><![CDATA[113]]></Location_Y>
<Scale><![CDATA[15]]></Scale>
<Label><![CDATA[ 广州市海珠区客村艺苑路 106号]]></Label>
<Poiname><![CDATA[]]></Poiname>
</SendLocationInfo>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXLocationSelectEventMessage;
            Assert.NotNull(msg);
            Assert.NotNull(msg.SendLocationInfo);
            Assert.Equal("6", msg.EventKey);

            Assert.Equal(23, msg.SendLocationInfo.Location_X);
            Assert.Equal(113, msg.SendLocationInfo.Location_Y);
            Assert.Equal(15, msg.SendLocationInfo.Scale);
            Assert.Equal(" 广州市海珠区客村艺苑路 106号", msg.SendLocationInfo.Label);
            Assert.Equal("", msg.SendLocationInfo.Poiname);
        }

        [Fact(DisplayName = "反序列化-点击菜单跳转小程序的事件推送")]
        public void De_Test_18()
        {
            string xml = @"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[view_miniprogram]]></Event>
<EventKey><![CDATA[pages/index/index]]></EventKey>
<MenuId>MENUID</MenuId>
</xml>";
            var msg = WXMessageBase.FromXml(xml) as WXViewMiniProgramEventMessage;
            Assert.NotNull(msg);
            Assert.Equal("pages/index/index", msg.EventKey);
            Assert.Equal("MENUID", msg.MenuId);
        }



    }
}
