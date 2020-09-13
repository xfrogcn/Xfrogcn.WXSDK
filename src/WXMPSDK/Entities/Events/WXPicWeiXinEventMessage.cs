using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 弹出微信相册发图器的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXPicWeiXinEventMessage : WXPicSysPhotoEventMessage
    {
        public override string Event
        {
            get => WXMsgEventNames.PicWeiXin;
            set => base.Event = WXMsgEventNames.PicWeiXin;
        }

        public override string Action => "选择微信相册图片";
    }
}
