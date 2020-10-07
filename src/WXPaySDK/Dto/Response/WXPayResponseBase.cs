using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [Serializable]
    public class WXPayResponseBase : WXPayBase
    {
        /// <summary>
        /// SUCCESS/FAIL 此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        [XmlElement("return_msg")]
        public string ReturnMsg { get; set; }

        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }

        public bool IsSuccess()
        {
            return ReturnCode == "SUCCESS" && ResultCode == "SUCCESS";
        }
    }
}
