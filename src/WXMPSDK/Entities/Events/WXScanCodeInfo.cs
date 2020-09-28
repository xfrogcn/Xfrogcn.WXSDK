using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 扫描信息
    /// </summary>
    [XmlRoot(ElementName = "ScanCodeInfo")]
    [Serializable]
    public class WXScanCodeInfo
    {
        /// <summary>
        /// 扫描类型，一般是qrcode
        /// </summary>
        [XmlElement(ElementName = "ScanType")]
        public string ScanType { get; set; }

        /// <summary>
        /// 扫描结果，即二维码对应的字符串信息
        /// </summary>
        [XmlElement(ElementName = "ScanResult")]
        public string ScanResult { get; set; }
    }
}
