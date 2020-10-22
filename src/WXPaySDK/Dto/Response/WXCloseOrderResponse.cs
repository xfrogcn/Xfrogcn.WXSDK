using System;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [XmlRoot("xml")]
    [Serializable]
    public class WXCloseOrderResponse : WXPayResponseBase
    {
    }
}
