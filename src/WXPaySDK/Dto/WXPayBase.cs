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
    public class WXPayBase
    {
        /// <summary>
        /// 随机字符串
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }



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
