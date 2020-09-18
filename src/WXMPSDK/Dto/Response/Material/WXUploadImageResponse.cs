using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 上传图文消息内的图片获取URL应答
    /// </summary>
    public class WXUploadImageResponse : WXResponse
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
