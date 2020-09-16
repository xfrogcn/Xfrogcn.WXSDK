using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 音频消息菜单
    /// </summary>
    public class MenuVoiceMessageButton: MenuValueButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.Voice;
    }

    /// <summary>
    /// 视频消息菜单
    /// </summary>
    public class MenuVideoMessageButton: MenuValueButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.Video;
    }

    /// <summary>
    /// 图片消息菜单
    /// </summary>
    public class MenuImageMessageButton: MenuValueButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.Image;
    }

    /// <summary>
    /// 文本消息菜单
    /// </summary>
    public class MenuTextMessageButton: MenuValueButton
    {
        [JsonPropertyName("type")]
        public override MenuButtonTypeEnum Type => MenuButtonTypeEnum.Text;
    }


    public abstract class MenuValueButton : MenuButtonBase
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
