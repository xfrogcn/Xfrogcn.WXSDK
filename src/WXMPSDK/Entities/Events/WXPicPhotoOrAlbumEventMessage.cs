using System;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 弹出拍照或者相册发图的事件推送
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class WXPicPhotoOrAlbumEventMessage : WXPicSysPhotoEventMessage
    {
        public override string Event
        {
            get => WXMsgEventNames.PicPhotoOrAlbum;
            set => base.Event = WXMsgEventNames.PicPhotoOrAlbum;
        }

        public override string Action => "选择照片";
    }
}
