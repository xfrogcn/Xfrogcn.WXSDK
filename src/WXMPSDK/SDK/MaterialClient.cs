using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    /// <summary>
    /// 素材管理
    /// </summary>
    public class MaterialClient
    {
        private static Dictionary<MaterialTypeEnum, string> materialTypeMapper
            = new Dictionary<MaterialTypeEnum, string>()
            {
                { MaterialTypeEnum.Image, "image" },
                { MaterialTypeEnum.Video, "voice" },
                { MaterialTypeEnum.Voice, "video" },
                { MaterialTypeEnum.Thumb, "thumb" },
            };

        static string FILE_KEY = "media";

        private HttpClient _client;
        public MaterialClient(HttpClient client)
        {
            _client = client;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        /// <summary>
        /// 上传临时素材
        /// </summary>
        /// <param name="mediaType">素材类型</param>
        /// <param name="file">文件路径</param>
        /// <returns></returns>
        public async Task<WXMediaUploadResponse> UploadTempMaterial(MaterialTypeEnum mediaType, string file)
        {
            NameValueCollection qs = new NameValueCollection()
            {
                {"type", materialTypeMapper[mediaType] }
            };
            return await _client.UploadFile<WXMediaUploadResponse>("cgi-bin/media/upload", FILE_KEY, file, null, HttpMethod.Post.Method, qs);
        }

        /// <summary>
        /// 下载临时素材
        /// </summary>
        /// <param name="mediaId"></param>
        /// <returns></returns>
        public async Task<WXStreamResponse> GetTempMaterial(string mediaId)
        {
            WXStreamResponse response = null;
            string url = $"cgi-bin/media/get?media_id={WebUtility.UrlEncode(mediaId)}";
            HttpResponseMessage r = await _client.GetAsync(url);
            if(r.Content.Headers.ContentType.MediaType== "text/plain")
            {
                response = await r.GetObjectAsync<WXStreamResponse>();
            }
            else
            {
                response = new WXStreamResponse()
                {
                    Stream = await r.Content.ReadAsStreamAsync()
                };
            }
            return response;
        }

        /// <summary>
        /// Jssdk临时素材
        /// </summary>
        /// <param name="mediaId"></param>
        /// <returns></returns>
        public async Task<WXStreamResponse> GetJSSDKTempMaterial(string mediaId)
        {
            WXStreamResponse response = null;
            string url = $"cgi-bin/media/get/jssdk?media_id={WebUtility.UrlEncode(mediaId)}";
            HttpResponseMessage r = await _client.GetAsync(url);
            if (r.Content.Headers.ContentType.MediaType == "text/plain")
            {
                response = await r.GetObjectAsync<WXStreamResponse>();
            }
            else
            {
                response = new WXStreamResponse()
                {
                    Stream = await r.Content.ReadAsStreamAsync()
                };
            }
            return response;
        }

        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WXAddNewsResponse> AddNews(WXAddNewsRequest request)
        {
            return await _client.PostAsync<WXAddNewsResponse>("cgi-bin/material/add_news", request);
        }

        /// <summary>
        /// 删除不再需要的永久素材
        /// </summary>
        /// <param name="mediaId"></param>
        /// <returns></returns>
        public async Task<WXResponse> DeleteMaterial(string mediaId)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/material/del_material", new
            {
                media_id = mediaId
            });
        }
    }
}
