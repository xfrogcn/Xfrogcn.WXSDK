using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    public class WXH5JSAPIConfig
    {
        [XmlElement("appId")]
        [JsonPropertyName("appId")]
        public string AppId { get; set; }

        [XmlElement("timeStamp")]
        [JsonPropertyName("timeStamp")]
        public string TimeStamp { get; set; }

        [XmlElement("nonceStr")]
        [JsonPropertyName("nonceStr")]
        public string NonceStr { get; set; }

        [XmlElement("package")]
        [JsonPropertyName("package")]
        public string Package { get; set; }

        [XmlElement("signType")]
        [JsonPropertyName("signType")]
        public string SignType { get; set; }

        [XmlElement("paySign")]
        [JsonPropertyName("paySign")]
        public string PaySign { get; set; }
    }
}
