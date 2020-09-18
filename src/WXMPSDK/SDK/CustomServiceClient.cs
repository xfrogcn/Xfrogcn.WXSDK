using System;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    /// <summary>
    /// 客服服务
    /// </summary>
    public class CustomServiceClient
    {
        private static HttpClient _client;
        public CustomServiceClient(HttpClient client)
        {
            _client = client;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        /// <summary>
        /// 添加客服账号
        /// </summary>
        /// <param name="accountInfo">账号信息</param>
        /// <returns></returns>
        public async Task<WXResponse> AddKfAccount(WXCustomInfo accountInfo)
        {
            return await _client.PostAsync<WXResponse>("customservice/kfaccount/add", accountInfo);
        }

        /// <summary>
        /// 修改客服账号信息
        /// </summary>
        /// <param name="accountInfo">账号信息</param>
        /// <returns></returns>
        public async Task<WXResponse> UpdateKfAccount(WXCustomInfo accountInfo)
        {
            return await _client.PostAsync<WXResponse>("customservice/kfaccount/update", accountInfo);
        }

        /// <summary>
        /// 删除客服账号
        /// </summary>
        /// <param name="accountName">客户账号名称</param>
        /// <returns></returns>
        public async Task<WXResponse> DelKfAccount(string accountName)
        {
            return await _client.PostAsync<WXResponse>("customservice/kfaccount/del", new
            {
                kf_account = accountName
            });
        }

        /// <summary>
        /// 设置客服帐号的头像
        /// </summary>
        /// <param name="accountName">账号名称</param>
        /// <param name="imgFilePath">头像图片路径</param>
        /// <returns></returns>
        public Task<WXResponse> UploadKfHeadImg(string accountName, string imgFilePath)
        {
            if (!File.Exists(imgFilePath))
            {
                return Task.FromResult(new WXResponse() { ErrCode = 404, ErrMsg = "头像文件不存在" });
            }
            string fileName = Path.GetFileName(imgFilePath);
            string mimeType = $"image/{Path.GetExtension(imgFilePath).TrimStart('.')}";
            return UploadKfHeadImg(accountName, File.OpenRead(imgFilePath), mimeType, fileName);
        }

        /// <summary>
        /// 设置客服帐号的头像
        /// </summary>
        /// <param name="accountName">账号名称</param>
        /// <param name="imgStream">图片流</param>
        /// <param name="mediaType">图片MIME类型</param>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public async Task<WXResponse> UploadKfHeadImg(string accountName, Stream imgStream, string mediaType, string fileName)
        {
            NameValueCollection qs = new NameValueCollection()
            {
                {"kf_account", accountName }
            };
            return await _client.UploadStreamAsync<WXResponse>(
                "customservice/kfaccount/uploadheadimg", "", imgStream, fileName, mediaType, null, null, HttpMethod.Post.Method, qs);
        }

        /// <summary>
        /// 获取所有客服账号
        /// </summary>
        /// <returns></returns>
        public async Task<WXCustomListResponse> GetKfList()
        {
            return await _client.GetAsync<WXCustomListResponse>("customservice/getkflist");
        }

        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public async Task<WXResponse> SendMessage(WXSendMessageBase msg)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/message/custom/send", msg);
        }

        /// <summary>
        /// 客服输入状态
        /// </summary>
        /// <param name="toUser">用户</param>
        /// <returns></returns>
        public async Task<WXResponse> SendTypingCommand(string toUser)
        {
            return await _client.PostAsync<WXResponse>("", new WXTypingCommand()
            {
                ToUser = toUser
            });
        }
    }
}
