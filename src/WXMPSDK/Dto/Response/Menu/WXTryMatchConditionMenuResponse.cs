using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 测试个性化菜单匹配结果
    /// </summary>
    public class WXTryMatchConditionMenuResponse : WXMenuDefine
    {
        [JsonPropertyName("errcode")]
        public int ErrCode { get; set; }

        [JsonPropertyName("errmsg")]
        public string ErrMsg { get; set; }
    }
}
