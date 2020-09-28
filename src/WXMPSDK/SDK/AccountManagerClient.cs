using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    /// <summary>
    /// 账号管理
    /// 生成二维码
    /// 生成长连接转短连接
    /// </summary>
    public class AccountManagerClient
    {
        private HttpClient _client;
        public AccountManagerClient(HttpClient client)
        {
            _client = client;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        /// <summary>
        /// 创建临时二维码
        /// </summary>
        /// <param name="expireSeconds"></param>
        /// <param name="sceneId"></param>
        /// <returns></returns>
        public async Task<WXCreateQrCodeResponse> CreateQrCode(long expireSeconds, int sceneId)
        {
            if(expireSeconds<=0 || expireSeconds> 2592000)
            {
                throw new ArgumentException("过期时间不可超过30天");
            }
            if(sceneId<1 || sceneId> 100000)
            {
                throw new ArgumentException("场景ID必须在1到100000之间");
            }
            return await _client.PostAsync<WXCreateQrCodeResponse>("cgi-bin/qrcode/create", new
            {
                expire_seconds = expireSeconds,
                action_name = "QR_SCENE",
                action_info = new
                {
                    scene = new
                    {
                        scene_id = sceneId
                    }
                }
            });
        }

        /// <summary>
        /// 创建临时二维码
        /// </summary>
        /// <param name="expireSeconds"></param>
        /// <param name="sceneStr"></param>
        /// <returns></returns>
        public async Task<WXCreateQrCodeResponse> CreateQrCode(long expireSeconds, string sceneStr)
        {
            if (expireSeconds <= 0 || expireSeconds > 2592000)
            {
                throw new ArgumentException("过期时间不可超过30天");
            }
            if (string.IsNullOrEmpty(sceneStr) || sceneStr.Length<1 || sceneStr.Length>64)
            {
                throw new ArgumentException("场景字符串长度必须在1-64之间");
            }
            return await _client.PostAsync<WXCreateQrCodeResponse>("cgi-bin/qrcode/create", new
            {
                expire_seconds = expireSeconds,
                action_name = "QR_STR_SCENE",
                action_info = new
                {
                    scene = new
                    {
                        scene_str = sceneStr
                    }
                }
            });
        }

        /// <summary>
        /// 创建永久二维码
        /// </summary>
        /// <param name="expireSeconds">过期时间</param>
        /// <param name="sceneId">场景ID</param>
        /// <returns></returns>
        public async Task<WXCreateQrCodeResponse> CreateLimitQrCode(int sceneId)
        {
            if (sceneId < 1 || sceneId > 100000)
            {
                throw new ArgumentException("场景ID必须在1到100000之间");
            }
            return await _client.PostAsync<WXCreateQrCodeResponse>("cgi-bin/qrcode/create", new
            {
                action_name = "QR_LIMIT_SCENE",
                action_info = new
                {
                    scene = new
                    {
                        scene_id = sceneId
                    }
                }
            });
        }

        /// <summary>
        /// 创建永久二维码
        /// </summary>
        /// <param name="expireSeconds">过期时间</param>
        /// <param name="sceneStr">场景ID</param>
        /// <returns></returns>
        public async Task<WXCreateQrCodeResponse> CreateLimitQrCode(string sceneStr)
        {
            return await _client.PostAsync<WXCreateQrCodeResponse>("cgi-bin/qrcode/create", new
            {
                action_name = "QR_LIMIT_STR_SCENE",
                action_info = new
                {
                    scene = new
                    {
                        scene_str = sceneStr
                    }
                }
            });
        }

        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public async Task<Stream> GetQrCode(string ticket)
        {
            string url = $"cgi-bin/showqrcode?ticket={WebUtility.UrlEncode(ticket)}";

            HttpResponseMessage response = await _client.GetAsync(url);
            return await response.Content.ReadAsStreamAsync();
        }

        /// <summary>
        /// 长链接转短链接
        /// </summary>
        /// <param name="longUrl"></param>
        /// <returns></returns>
        public async Task<WXShortUrlResponse> ShortUrl(string longUrl)
        {
            return await _client.PostAsync<WXShortUrlResponse>("cgi-bin/shorturl", new
            {
                action = "long2short",
                long_url = longUrl
            });
        }
    }
}
