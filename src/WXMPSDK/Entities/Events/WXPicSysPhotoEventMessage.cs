using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 弹出系统拍照发图的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXPicSysPhotoEventMessage : WXEventKeyMessageBase
    {

        public override string Event
        {
            get => WXMsgEventNames.PicSysPhoto;
            set => base.Event = WXMsgEventNames.PicSysPhoto;
        }

        /// <summary>
        /// 发送的图片信息
        /// </summary>
        [XmlElement(ElementName = "SendPicsInfo")]
        public WXSendPicsInfo SendPicsInfo { get; set; }

        public override string Action => "选择系统照片";
    }
}
