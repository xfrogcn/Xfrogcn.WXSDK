﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using WXMPSDK.Dto;
using Xfrogcn.AspNetCore.Extensions;
using Xunit;

namespace WXMPSDKTests.SDK
{
    [Trait("", "Clients")]
    public class MenuDefineTest
    {
        [Fact(DisplayName = "De_Click")]
        public void TestClick()
        {
            MenuClickButton clickButton = new MenuClickButton()
            {
                Key = "key",
                Name = "name"
            };

            var json =  JsonSerializer.Serialize(clickButton);

            var btn = JsonSerializer.Deserialize<MenuItem>(json) as MenuClickButton;
            Assert.Equal("key", btn.Key);
            Assert.Equal("name", "name");
        }

        [Fact(DisplayName = "De_View")]
        public void TestVIew()
        {
            MenuViewButton viewButton = new MenuViewButton()
            {
                Name = "name",
                Url = "url"
            };
            JsonHelper jsonHelper = new JsonHelper();
            var json = jsonHelper.ToJson(viewButton);

            var btn = JsonSerializer.Deserialize<MenuItem>(json) as MenuViewButton;
            Assert.Equal("url", btn.Url);
            Assert.Equal("name", "name");
        }

        [Fact(DisplayName = "De_Buttons")]
        public void TestMenuButtons()
        {
            WXMenuDefine menu = new WXMenuDefine()
            {
                Buttons = new List<MenuItem>()
                {
                    new MenuClickButton(){ Name = "今日歌曲",Key = "V1001_TODAY_MUSIC"},
                    new MenuContainer(){ Name = "菜单", SubButtons = new List<MenuItem>()
                    {
                        new MenuViewButton(){ Name = "搜索", Url = "http://www.soso.com/"},
                        new MenuMiniProgramButton(){ Name = "wxa", Url= "http://mp.weixin.qq.com", AppId ="wx286b93c14bbf93aa", PagePath = "pages/lunar/index"},
                        new MenuContainer()
                        {
                            Name= "二级菜单",
                            SubButtons = new List<MenuItem>()
                            {
                                new MenuViewButton(){ Name = "view",  Url = "testurl"}
                            }
                        }
                    }
                    }
                }
            };

            JsonHelper jsonHelper = new JsonHelper();

            var json = jsonHelper.ToJson(menu);

            WXMenuDefine m = jsonHelper.ToObject<WXMenuDefine>(json);
            Assert.Equal(2, m.Buttons.Count);
            Assert.IsType<MenuClickButton>(menu.Buttons[0]);
            Assert.IsType<MenuContainer>(menu.Buttons[1]);
            Assert.IsType<MenuViewButton>((menu.Buttons[1] as MenuContainer).SubButtons[0]);

            Assert.Equal("wx286b93c14bbf93aa", ((menu.Buttons[1] as MenuContainer).SubButtons[1] as MenuMiniProgramButton).AppId);
            Assert.IsType<MenuViewButton>(((menu.Buttons[1] as MenuContainer).SubButtons[2] as MenuContainer).SubButtons[0]);


        }


        [Fact(DisplayName = "De_NotApiMenu_Response")]
        public void MenuResponseTest()
        {
            string json = Resource1.notApiMenuResponse;
            JsonHelper jsonHelper = new JsonHelper();

            var mr = jsonHelper.ToObject<WXMenuResponse>(json);
            Assert.NotNull(mr);
            Assert.Equal(1, mr.IsMenuOpen);
            Assert.IsType<MenuContainerForResponse>(mr.MenuInfo.Buttons[0]);
            Assert.IsType<MenuTextMessageButton>(mr.MenuInfo.Buttons[1]);
            Assert.IsType<MenuImageMessageButton>(mr.MenuInfo.Buttons[2]);

            var mcfr = mr.MenuInfo.Buttons[0] as MenuContainerForResponse;
            Assert.Equal(4, mcfr.SubButtons.List.Count);
            Assert.IsType<MenuViewButton>(mcfr.SubButtons.List[0]);
            Assert.IsType<MenuNewsMessageButton>(mcfr.SubButtons.List[1]);
            Assert.IsType<MenuVideoMessageButton>(mcfr.SubButtons.List[2]);
            Assert.IsType<MenuVoiceMessageButton>(mcfr.SubButtons.List[3]);

            json = jsonHelper.ToJson(mr);
        }

        [Fact(DisplayName = "De_ApiMenu_Response")]
        public void MenuResponseTest2()
        {
            string json = Resource1.apiMenuResponse;
            JsonHelper jsonHelper = new JsonHelper();

            var mr = jsonHelper.ToObject<WXMenuResponse>(json);
            Assert.NotNull(mr);
            Assert.Equal(1, mr.IsMenuOpen);
            Assert.IsType<MenuClickButton>(mr.MenuInfo.Buttons[0]);
            Assert.IsType<MenuContainerForResponse>(mr.MenuInfo.Buttons[1]);


            var mc = mr.MenuInfo.Buttons[1] as MenuContainerForResponse;
            Assert.Equal(3, mc.SubButtons.List.Count);
            Assert.IsType<MenuViewButton>(mc.SubButtons.List[0]);
            Assert.IsType<MenuViewButton>(mc.SubButtons.List[1]);
            Assert.IsType<MenuClickButton>(mc.SubButtons.List[2]);

            json = jsonHelper.ToJson(mr);
        }
    }
}
