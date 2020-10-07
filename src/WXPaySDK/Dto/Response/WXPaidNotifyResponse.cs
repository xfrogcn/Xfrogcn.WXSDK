using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WXPaySDK.Dto
{
    [Serializable]
    [XmlRoot("xml")]
    public class WXPaidNotifyResponse
    {
        /// <summary>
        /// SUCCESS/FAIL 此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        [XmlElement("return_msg")]
        public string ReturnMsg { get; set; }

        public virtual string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms, new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                NamespaceHandling = NamespaceHandling.OmitDuplicates
            });
            XmlSerializerNamespaces _namespaces = new XmlSerializerNamespaces(
                    new XmlQualifiedName[] {
                        new XmlQualifiedName(string.Empty, "")
                 });
            serializer.Serialize(writer, this, _namespaces);
            ms.Position = 0;
            TextReader reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }
    }
}
