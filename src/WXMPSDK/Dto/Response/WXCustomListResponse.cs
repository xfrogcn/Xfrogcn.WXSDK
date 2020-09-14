using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WXMPSDK.Dto
{
    public class WXCustomListResponse
    {
        /// <summary>
        /// 客服列表
        /// </summary>
        [JsonPropertyName("kf_list")]
        public List<WXCustomInfoResponse> KfList { get; set; }
    }


    public class WXCustomInfoResponse
    {
        [JsonPropertyName("kf_account")]
        public string KfAccount { get; set; }

        [JsonPropertyName("kf_nick")]
        public string NickName { get; set; }

        [JsonPropertyName("kf_id")]
        public string KfId { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        [JsonPropertyName("kf_headimgurl")]
        public string KfHeadImgUrl { get; set; }
    }
}
