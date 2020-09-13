using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 点击菜单跳转小程序的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXViewMiniProgramEventMessage : WXViewEventMessage
    {
        public override string Event
        {
            get => WXMsgEventNames.ViewMiniProgram;
            set => base.Event = WXMsgEventNames.ViewMiniProgram;
        }

        public override string Action => "点击菜单跳转小程序";
    }
}
