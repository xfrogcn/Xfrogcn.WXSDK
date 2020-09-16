using System;
using System.Collections.Generic;
using System.Text.Json;
using WXMPSDK.Dto;
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

            var json = JsonSerializer.Serialize(viewButton);

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
                        new MenuMiniProgramButton(){ Name = "wxa", Url= "http://mp.weixin.qq.com", AppId ="wx286b93c14bbf93aa", PagePath = "pages/lunar/index"}
                    }
                    }
                }
            };

            var json = JsonSerializer.Serialize(menu);

            WXMenuDefine m = JsonSerializer.Deserialize<WXMenuDefine>(json);
            Assert.Equal(2, m.Buttons.Count);
            Assert.IsType<MenuClickButton>(menu.Buttons[0]);
            Assert.IsType<MenuContainer>(menu.Buttons[1]);
            Assert.IsType<MenuViewButton>((menu.Buttons[1] as MenuContainer).SubButtons[0]);

            Assert.Equal("wx286b93c14bbf93aa", ((menu.Buttons[1] as MenuContainer).SubButtons[1] as MenuMiniProgramButton).AppId);



        }
    }
}
