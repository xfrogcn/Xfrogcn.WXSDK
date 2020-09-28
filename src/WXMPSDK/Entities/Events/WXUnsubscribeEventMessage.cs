using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXUnsubscribeEventMessage : WXEventMessageBase
    {
        public override string Event
        {
            get => WXMsgEventNames.Unsubscribe;
            set => base.Event = WXMsgEventNames.Unsubscribe;
        }

        public override string Action => "取消关注公众号";
    }
}
