using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 个性化菜单接口应答
    /// </summary>
    public class WXConditionalMenuResponse
    {
        [JsonPropertyName("menuid")]
        public string MenuId { get; set; }
    }
}
