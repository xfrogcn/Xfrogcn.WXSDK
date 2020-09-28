using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 扫码推事件且弹出“消息接收中”提示框的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXScanCodeWaitMsgEventMessage : WXScanCodePushEventMessage
    {
        public override string Event
        {
            get => WXMsgEventNames.ScanCodeWaitmsg;
            set => base.Event = WXMsgEventNames.ScanCodeWaitmsg;
        }

        public override string Action => "扫码提示";
    }
}
