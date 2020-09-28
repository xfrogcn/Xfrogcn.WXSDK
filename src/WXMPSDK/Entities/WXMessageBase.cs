using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WXMPSDK.Entities
{
    /// <summary>
    /// 微信消息基类
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class WXMessageBase
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        [XmlElement(ElementName = "ToUserName")]
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        [XmlElement(ElementName = "FromUserName")]
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        [XmlElement(ElementName = "CreateTime")]
        public long CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// <seealso cref="WXMsgTypes"/>
        /// </summary>
        [XmlElement(ElementName = "MsgType")]
        public virtual string MsgType { get; set; }

        [XmlIgnore]
        public virtual string Action { get; }


        public virtual string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms, new XmlWriterSettings()
            {
                OmitXmlDeclaration =true,
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


        public static WXMessageBase FromXml(string xml)
        {
            return SerializeUtils.Deserialize(xml);
        }
    }
}
