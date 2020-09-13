using System;
namespace WXMPSDK.Entities
{
    public class WXMsgEventNames
    {
        /// <summary>
        /// 订阅
        /// </summary>
        public const string Subscribe = "subscribe";

        /// <summary>
        /// 取消订阅
        /// </summary>
        public const string Unsubscribe = "unsubscribe";

        /// <summary>
        /// 扫描二维码事件（当已关注公众号时推送此事件）
        /// </summary>
        public const string Scan = "SCAN";

        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        public const string Location = "LOCATION";

        /// <summary>
        /// 自定义菜单事件
        /// </summary>
        public const string Click = "CLICK";

        /// <summary>
        /// 点击菜单跳转链接时的事件推送
        /// </summary>
        public const string View = "VIEW";

        /// <summary>
        /// 扫码推事件的事件推送
        /// </summary>
        public const string ScanCodePush = "scancode_push";

        /// <summary>
        /// 扫码推事件且弹出“消息接收中”提示框的事件推送
        /// </summary>
        public const string ScanCodeWaitmsg = "scancode_waitmsg";

        /// <summary>
        /// 弹出系统拍照发图的事件推送
        /// </summary>
        public const string PicSysPhoto = "pic_sysphoto";

        /// <summary>
        /// 弹出拍照或者相册发图的事件推送
        /// </summary>
        public const string PicPhotoOrAlbum = "pic_photo_or_album";

        /// <summary>
        /// 弹出微信相册发图器的事件推送
        /// </summary>
        public const string PicWeiXin = "pic_weixin";

        /// <summary>
        /// 弹出地理位置选择器的事件推送
        /// </summary>
        public const string LocationSelect = "location_select";

        /// <summary>
        /// 点击菜单跳转小程序的事件推送
        /// </summary>
        public const string ViewMiniProgram = "view_miniprogram";
    }
}
