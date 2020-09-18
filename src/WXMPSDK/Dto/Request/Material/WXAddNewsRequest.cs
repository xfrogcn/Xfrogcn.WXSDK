using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    /// <summary>
    /// 新增图文素材请求
    /// </summary>
    public class WXAddNewsRequest
    {
        [JsonPropertyName("articles")]
        public List<WXAddNewsArticleItem> Articles { get; set; }
    }

    public class WXAddNewsArticleItem : WXArticleItem
    {
        /// <summary>
        /// Uint32 是否打开评论，0不打开，1打开
        /// </summary>
        [JsonPropertyName("need_open_comment")]
        public int NeedOpenComment { get; set; }

        /// <summary>
        /// Uint32 是否粉丝才可评论，0所有人可评论，1粉丝才可评论
        /// </summary>
        [JsonPropertyName("only_fans_can_comment")]
        public int OnlyFansCanComment { get; set; }
    }



    
}
