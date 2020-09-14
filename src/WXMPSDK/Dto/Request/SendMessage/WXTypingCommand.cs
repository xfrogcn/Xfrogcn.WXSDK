using System;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 客服输入状态
    /// </summary>
    public class WXTypingCommand
    {
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }

        [JsonPropertyName("command")]
        public string Command => "Typing";
    }
}
