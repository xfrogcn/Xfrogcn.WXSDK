using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WXMPSDK.Entities;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 菜单消息
    /// </summary>
    public class WXMsgMenuSendMessage : WXSendMessageBase
    {
        [JsonPropertyName("msgtype")]
        public override string MsgType => WXMsgTypes.MsgMenu;

        [JsonPropertyName("msgmenu")]
        public WXRequestMsgMenuContent MsgMenu { get; set; }
    }


    public class WXRequestMsgMenuContent
    {
     
        [JsonPropertyName("head_content")]
        public string HeadContent { get; set; }

  
        [JsonPropertyName("list")]
        public List<WXRequestMenuItem> List { get; set; }

        [JsonPropertyName("tail_content")]
        public string TailContent { get; set; }
    }

    public class WXRequestMenuItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
