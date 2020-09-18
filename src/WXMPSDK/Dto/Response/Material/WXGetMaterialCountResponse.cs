using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 获取永久素材总数
    /// 1.永久素材的总数，也会计算公众平台官网素材管理中的素材 2.图片和图文消息素材（包括单图文和多图文）的总数上限为5000，其他素材的总数上限为1000
    /// </summary>
    public class WXGetMaterialCountResponse : WXResponse
    {
        [JsonPropertyName("voice_count")]
        public int VoiceCount { get; set; }

        [JsonPropertyName("video_count")]
        public int VideoCount { get; set; }

        [JsonPropertyName("image_count")]
        public int ImageCount { get; set; }

        [JsonPropertyName("news_count")]
        public int NewsCount { get; set; }
    }
}
