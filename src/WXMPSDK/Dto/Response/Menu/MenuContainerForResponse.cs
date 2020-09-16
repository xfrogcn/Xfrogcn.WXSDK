using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取菜单定义
    /// </summary>
    public class WXMenuResponse: WXResponse
    {
        [JsonPropertyName("is_menu_open")]
        public int IsMenuOpen { get; set; }

        [JsonPropertyName("selfmenu_info")]
        public SelfMenuInfo MenuInfo { get; set; }
    }

    /// <summary>
    /// 菜单信息
    /// </summary>
    public class SelfMenuInfo
    {
        [JsonPropertyName("button")]
        public List<MenuItem> Buttons { get; set; }
    }


    /// <summary>
    /// 菜单应答定义
    /// </summary>
    public class MenuContainerForResponse : MenuItem
    {
        [JsonPropertyName("sub_button")]
        public MenuContainerButtons SubButtons { get; set; }
    }

    public class MenuContainerButtons
    {
        [JsonPropertyName("list")]
        public List<MenuItem> List { get; set; }
    }
}
