using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXUnifiedOrderRequest : WXPayRequestBase
    {
        

        /// <summary>
        /// 设备号
        /// 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }



        /// <summary>
        /// 商品简单描述，该字段请按照规范传递
        /// </summary>
        [XmlElement("body")]
        public string Body { get; set; }

        /// <summary>
        /// 商品详细描述，对于使用单品优惠的商户，该字段必须按照规范上传，详见“单品优惠参数说明”
        /// </summary>
        [XmlElement("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用。
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 标价币种
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; } = "CNY";

        /// <summary>
        /// 订单总金额，单位为分，详见支付金额
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 终端IP 支持IPV4和IPV6两种格式的IP地址。用户的客户端IP
        /// </summary>
        [XmlElement("spbill_create_ip")]
        public string SpBillCreateIp { get; set; }

        /// <summary>
        /// 交易起始时间
        /// 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。
        /// </summary>
        [XmlElement("time_start")]
        public string TimeStart { get; set; }

        /// <summary>
        /// 订单失效时间，格式为yyyyMMddHHmmss，
        /// 如2009年12月27日9点10分10秒表示为20091227091010。
        /// 订单失效时间是针对订单号而言的，
        /// 由于在请求支付的时候有一个必传参数prepay_id只有两小时的有效期，
        /// 所以在重入时间超过2小时的时候需要重新请求下单接口获取新的prepay_id。
        /// time_expire只能第一次下单传值，不允许二次修改，二次修改系统将报错。
        /// </summary>
        [XmlElement("time_expire")]
        public string TimeExpire { get; set; }

        /// <summary>
        /// 订单优惠标记，使用代金券或立减优惠功能时需要的参数，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("goods_tag")]
        public string GoodsTag { get; set; }

        /// <summary>
        /// 异步接收微信支付结果通知的回调地址，通知url必须为外网可访问的url，不能携带参数。
        /// </summary>
        [XmlElement("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 交易类型
        /// JSAPI -JSAPI支付  NATIVE -Native支付 APP -APP支付
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// trade_type=NATIVE时，此参数必传。此参数为二维码中包含的商品ID，商户自行定义。
        /// </summary>
        [XmlElement("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// 上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        [XmlElement("limit_pay")]
        public string LimitPay { get; set; }

        /// <summary>
        /// trade_type=JSAPI时（即JSAPI支付），此参数必传，此参数为微信用户在商户对应appid下的唯一标识。
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// Y，传入Y时，支付成功消息和支付详情页将出现开票入口。需要在微信支付商户平台或微信公众平台开通电子发票功能，传此字段才可生效
        /// </summary>
        [XmlElement("receipt")]
        public string Receipt { get; set; }

        /// <summary>
        /// 该字段常用于线下活动时的场景信息上报，支持上报实际门店信息，
        /// 商户也可以按需求自己上报相关信息。该字段为JSON对象数据，
        /// 对象格式为{"store_info":{"id": "门店ID","name": "名称","area_code": "编码","address": "地址" }} 
        /// </summary>
        [XmlElement("scene_info")]
        public string SceneInfo { get; set; }
    }
}
