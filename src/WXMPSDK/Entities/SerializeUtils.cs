using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace WXMPSDK.Entities
{
    public static class SerializeUtils
    {
        private static Dictionary<string, Type> eventMessageTypeMapper
            = new Dictionary<string, Type>()
            {
                { WXMsgEventNames.Click, typeof(WXClickEventMessage) },
                { WXMsgEventNames.Location, typeof(WXLocationEventMessage) },
                { WXMsgEventNames.LocationSelect, typeof(WXLocationSelectEventMessage) },
                { WXMsgEventNames.PicPhotoOrAlbum, typeof(WXPicPhotoOrAlbumEventMessage) },
                { WXMsgEventNames.PicSysPhoto, typeof(WXPicSysPhotoEventMessage) },
                { WXMsgEventNames.PicWeiXin, typeof(WXPicWeiXinEventMessage) },
                { WXMsgEventNames.Scan, typeof(WXScanEventMessage) },
                { WXMsgEventNames.ScanCodePush, typeof(WXScanCodePushEventMessage) },
                { WXMsgEventNames.ScanCodeWaitmsg, typeof(WXScanCodeWaitMsgEventMessage) },
                { WXMsgEventNames.Subscribe, typeof(WXSubscribeEventMessage) },
                { WXMsgEventNames.Unsubscribe, typeof(WXUnsubscribeEventMessage) },
                { WXMsgEventNames.View, typeof(WXViewEventMessage) },
                { WXMsgEventNames.ViewMiniProgram, typeof(WXViewMiniProgramEventMessage) },
            };

        private static Dictionary<string, Type> receiveMsgTypeMapper
            = new Dictionary<string, Type>()
            {
                { WXMsgTypes.Image, typeof(WXImageReceiveMessage) },
                { WXMsgTypes.Link, typeof(WXLinkReceiveMessage) },
                { WXMsgTypes.Location, typeof(WXLocationReceiveMessage) },
                { WXMsgTypes.ShortVideo, typeof(WXShortVideoReceiveMessage) },
                { WXMsgTypes.Text, typeof(WXTextReceiveMessage) },
                { WXMsgTypes.Video, typeof(WXVideoReceiveMessage) },
                { WXMsgTypes.Voice, typeof(WXVoiceReceiveMessage) }
            };


        public static WXMessageBase Deserialize(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }

            XElement element = XElement.Parse(xml);
            if (element.Name != "xml")
            {
                return null;
            }

            string msgType = element.Elements("MsgType").FirstOrDefault()?.Value;
            if (string.IsNullOrEmpty(msgType))
            {
                return null;
            }

            if (msgType == WXMsgTypes.Event)
            {
                string eventType = element.Elements("Event").FirstOrDefault()?.Value;
                if (string.IsNullOrEmpty(eventType))
                {
                    return null;
                }

                Type t = null;
                if (eventMessageTypeMapper.ContainsKey(eventType))
                {
                    t = eventMessageTypeMapper[eventType];
                }
                if (t == null)
                {
                    return null;
                }

                XmlSerializer serializer = new XmlSerializer(t);
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                WXMessageBase msg = serializer.Deserialize(ms) as WXMessageBase;
                return msg;
            }
            else if (receiveMsgTypeMapper.ContainsKey(msgType))
            {
                XmlSerializer serializer = new XmlSerializer(receiveMsgTypeMapper[msgType]);
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                WXMessageBase msg = serializer.Deserialize(ms) as WXMessageBase;
                return msg;
            }



            return null;

        }
    }
}
