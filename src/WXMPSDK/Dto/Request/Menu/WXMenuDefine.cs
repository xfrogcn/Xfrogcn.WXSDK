using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXMenuDefine
    {
        [JsonPropertyName("button")]
        public List<MenuItem> Buttons { get; set; }

        [JsonPropertyName("matchrule")]
        public MenuMatchRule MatchRule { get; set; }
    }

    public class MenuMatchRule
    {
        /// <summary>
        /// 用户标签的id，可通过用户标签管理接口获取
        /// </summary>
        [JsonPropertyName("tag_id")]
        public int TagId { get; set; }

        /// <summary>
        /// 性别：男（1）女（2），不填则不做匹配
        /// </summary>
        [JsonPropertyName("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// 国家信息，是用户在微信中设置的地区，具体请参考地区信息表
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// 省份信息，是用户在微信中设置的地区，具体请参考地区信息表
        /// </summary>
        [JsonPropertyName("province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市信息，是用户在微信中设置的地区，具体请参考地区信息表
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// 客户端版本，当前只具体到系统型号：IOS(1), Android(2),Others(3)，不填则不做匹配
        /// </summary>
        [JsonPropertyName("client_platform_type")]
        public string ClientPlatformType { get; set; }

        /// <summary>
        /// 语言信息，是用户在微信中设置的语言，具体请参考语言表： 1、简体中文 "zh_CN" 2、繁体中文TW "zh_TW" 3、繁体中文HK "zh_HK" 4、英文 "en" 5、印尼 "id" 6、马来 "ms" 7、西班牙 "es" 8、韩国 "ko" 9、意大利 "it" 10、日本 "ja" 11、波兰 "pl" 12、葡萄牙 "pt" 13、俄国 "ru" 14、泰文 "th" 15、越南 "vi" 16、阿拉伯语 "ar" 17、北印度 "hi" 18、希伯来 "he" 19、土耳其 "tr" 20、德语 "de" 21、法语 "fr"
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class MenuViewLimitedButton: MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.ViewLimited;

        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
    }

    public class MenuMediaIdButton: MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.MediaId;

        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }
    }

    public class MenuLocationSelectButton : MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.LocationSelect;
    }

    public class MenuPicWeiXinButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.PicWeiXin;
    }

    public class MenuPicPhotoOrAlbumButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.PicPhotoOrAlbum;
    }

    public class MenuPicSysPhotoButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.PicSysPhoto;
    }


    public class MenuScanCodePushButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.ScanCodePush;
    }

    public class MenuScanCodeWaitMsgButton: MenuClickButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.ScanCodeWaitMsg;
    }

    public class MenuMiniProgramButton: MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.MiniProgram;

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        [JsonPropertyName("pagepath")]
        public string PagePath { get; set; }
    }

    public class MenuViewButton: MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.View;

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class MenuClickButton : MenuButtonBase
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.Click;

        [JsonPropertyName("key")]
        public string Key { get; set; }
    }

    public class MenuContainer : MenuItem
    {
        [JsonPropertyName("sub_button")]
        public List<MenuItem> SubButtons { get; set; }
    }

    
    public abstract class MenuButtonBase : MenuItem
    {
        [JsonPropertyName("type")]
        public abstract MenuButtonTypeEnum Type { get; }

    }

    [JsonConverter(typeof(WXMenuItemConverter))]
    public class MenuItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    //[JsonConverter(typeof(MenuButtonTypeEnumConverter))]
    

}
