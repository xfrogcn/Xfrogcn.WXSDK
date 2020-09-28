using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 点击菜单跳转链接时的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXViewEventMessage : WXEventKeyMessageBase
    {
        public override string Event
        {
            get => WXMsgEventNames.View;
            set => base.Event = WXMsgEventNames.View;
        }

        /// <summary>
        /// 指菜单ID，如果是个性化菜单，则可以通过这个字段，知道是哪个规则的菜单被点击了。
        /// </summary>
        [XmlElement(ElementName = "MenuId")]
        public string MenuId { get; set; }

        public override string Action => "点击菜单跳转";
    }
}
