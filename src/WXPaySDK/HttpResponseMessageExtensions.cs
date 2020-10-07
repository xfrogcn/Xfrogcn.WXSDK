using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WXPaySDK
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TEntity> GetXmlObject<TEntity>(this HttpResponseMessage msg)
            where TEntity: class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TEntity));

            return serializer.Deserialize(await msg.Content.ReadAsStreamAsync()) as TEntity;
        }
    }
}
