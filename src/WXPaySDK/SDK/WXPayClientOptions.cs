using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXPaySDK.SDK
{
    public class WXPayClientItem
    {
        public string Name { get; set; }
        public string AppId { get; set; }

        public string MchId { get; set; }

        public string Key { get; set; }
    }
    public class WXPayClientOptions
    {
        private readonly List<WXPayClientItem> _clients = new List<WXPayClientItem>();
        public IReadOnlyList<WXPayClientItem> Clients => _clients.AsReadOnly();

        public void AddClient(string name, string appId, string mchId, string key)
        {
            var old = _clients.FirstOrDefault(i => i.Name == name);
            if (old != null)
            {
                old.AppId = appId;
                old.MchId = mchId;
                old.Key = key;
            }
            else
            {
                _clients.Add(new WXPayClientItem()
                {
                    Name = name,
                    AppId = appId,
                    Key = key,
                    MchId = mchId
                });
            }
        }
    }
}
