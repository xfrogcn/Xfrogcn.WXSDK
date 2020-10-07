using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WXPaySDK.SDK;

namespace WXPaySDK.Dto
{
    [Serializable]
    public class WXPayRequestBase : WXPayBase
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string MchId { get; set; }
        /// <summary>
        /// 签名类型，默认为MD5，支持HMAC-SHA256和MD5。
        /// </summary>
        [XmlElement("sign_type")]
        public string SignType { get; set; } = "MD5";


        internal void FillClientInfo(WXPayClientItem ci)
        {
            if (ci != null)
            {
                AppId = ci.AppId;
                MchId = ci.MchId;
                this.ComputeAndSetSign(ci.Key);
            }
        }
    }
}
