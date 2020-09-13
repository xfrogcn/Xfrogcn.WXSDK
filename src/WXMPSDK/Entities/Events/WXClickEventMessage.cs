using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 点击菜单拉取消息时的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXClickEventMessage : WXEventKeyMessageBase
    {
        public override string Event
        {
            get => WXMsgEventNames.Click;
            set => base.Event = WXMsgEventNames.Click;
        }

        public override string Action => "点击菜单";
    }
}
