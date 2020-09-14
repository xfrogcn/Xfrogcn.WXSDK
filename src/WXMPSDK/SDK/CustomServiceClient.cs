using System;
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

        public Task<WXResponse> UploadKfHeadImg(string accountName, string imgFilePath)
        {
            if (!File.Exists(imgFilePath))
            {
                return Task.FromResult(new WXResponse() { ErrCode = 404, ErrMsg = "头像文件不存在" });
            }
            return UploadKfHeadImg(accountName, File.OpenRead(imgFilePath));
        }

        public async Task<WXResponse> UploadKfHeadImg(string accountName, Stream imgStream)
        {
            return new WXResponse();
        }

        public async Task<WXCustomListResponse> GetKfList()
        {
            return await _client.GetAsync<WXCustomListResponse>("customservice/getkflist");
        }
    }
}
