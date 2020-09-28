using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 扫码推事件的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXScanCodePushEventMessage : WXEventKeyMessageBase
    {
        public override string Event
        {
            get => WXMsgEventNames.ScanCodePush;
            set => base.Event = WXMsgEventNames.ScanCodePush;
        }

        /// <summary>
        /// 扫描信息
        /// </summary>
        [XmlElement(ElementName = "ScanCodeInfo")]
        public WXScanCodeInfo ScanCodeInfo { get; set; }

        public override string Action => "扫码";
    }
}
