using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WXMPSDK.Dto;
using Xfrogcn.AspNetCore.Extensions;

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

       
        private readonly HttpClient _client;
        private readonly FileExtensionContentTypeProvider _mimeProvider;
        private readonly JsonHelper _jsonHelper;

        public MaterialClient(HttpClient client):this(client, null)
        {

        }

        public MaterialClient(HttpClient client, 
            FileExtensionContentTypeProvider mimeProvider)
        {
            _client = client;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
            _mimeProvider = mimeProvider;
            if (_mimeProvider == null)
            {
                _mimeProvider = new FileExtensionContentTypeProvider();
            }
            _jsonHelper = new JsonHelper();
        }

        protected string GetFileMimeType(string filePath)
        {
            string contentType = "";
            _mimeProvider.TryGetContentType(filePath, out contentType);
            if (string.IsNullOrEmpty(contentType))
            {
                contentType = MediaTypeNames.Application.Octet;
            }
            return contentType;
        }

        /// <summary>
        /// 上传临时素材
        /// </summary>
        /// <param name="mediaType">素材类型</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public async Task<WXMediaUploadResponse> UploadTempMaterial(MaterialTypeEnum mediaType, string filePath)
        {
            NameValueCollection qs = new NameValueCollection()
            {
                {"type", materialTypeMapper[mediaType] }
            };

            string contentType = GetFileMimeType(filePath);

            return await _client.UploadFileAsync<WXMediaUploadResponse>("cgi-bin/media/upload", "", filePath, contentType, null, null, HttpMethod.Post.Method, qs);
        }

        public async Task<WXMediaUploadResponse> UploadTempMaterial(MaterialTypeEnum mediaType, Stream stream, string mimeType, string fileName)
        {
            NameValueCollection qs = new NameValueCollection()
            {
                {"type", materialTypeMapper[mediaType] }
            };

            return await _client.UploadStreamAsync<WXMediaUploadResponse>("cgi-bin/media/upload", "", stream, fileName, mimeType, null, null, HttpMethod.Post.Method, qs);
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
        /// 修改图文素材
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WXResponse> UpdateNews(WXUpdateNewsRequest request)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/material/update_news", request);
        }

        /// <summary>
        /// 上传图文消息内的图片获取URL
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public async Task<WXUploadImageResponse> UploadImage(string filePath)
        {
            string contentType = GetFileMimeType(filePath);

            return await _client.UploadFileAsync<WXUploadImageResponse>("cgi-bin/media/uploadimg", "", filePath, contentType);
        }

        public async Task<WXUploadImageResponse> UploadImage(Stream stream, string mimeType, string fileName)
        {
            return await _client.UploadStreamAsync<WXUploadImageResponse>("cgi-bin/media/uploadimg", "", stream, fileName, mimeType);
        }

        /// <summary>
        /// 上传永久素材
        /// </summary>
        /// <param name="mediaType">素材类型</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="title">标题，视频类型时需要提供</param>
        /// <param name="introduction">说明，视频类型时需要提供</param>
        /// <returns>应答</returns>
        public async Task<WXAddMaterialResponse> AddMaterial(MaterialTypeEnum mediaType, string filePath, string title, string introduction)
        {
            Dictionary<string, string> formData = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(introduction))
            {
                formData.Add("description", _jsonHelper.ToJson(new
                {
                    title,
                    introduction
                }));
            }

            NameValueCollection queryString = new NameValueCollection()
            {
                {"type", materialTypeMapper[mediaType] }
            };

            string contentType = GetFileMimeType(filePath);

            return await _client.UploadFileAsync<WXAddMaterialResponse>("cgi-bin/material/add_material",
                "", filePath, contentType, "", formData, HttpMethod.Post.Method, queryString);
        }

        /// <summary>
        /// 上传永久素材，流方式
        /// </summary>
        /// <param name="mediaType">素材类型</param>
        /// <param name="stream">数据流</param>
        /// <param name="mimeType">类型</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="title">标题，视频类型时需要提供</param>
        /// <param name="introduction">说明，视频类型时需要提供</param>
        /// <returns>应答</returns>
        public async Task<WXAddMaterialResponse> AddMaterial(MaterialTypeEnum mediaType, Stream stream, string mimeType, string fileName, string title, string introduction)
        {
            Dictionary<string, string> formData = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(introduction))
            {
                formData.Add("description", _jsonHelper.ToJson(new
                {
                    title,
                    introduction
                }));
            }

            NameValueCollection queryString = new NameValueCollection()
            {
                {"type", materialTypeMapper[mediaType] }
            };


            return await _client.UploadStreamAsync<WXAddMaterialResponse>("cgi-bin/material/add_material",
                "", stream, fileName, mimeType, "", formData, HttpMethod.Post.Method, queryString);
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

        /// <summary>
        /// 获取永久素材总数
        /// </summary>
        /// <returns></returns>
        public async Task<WXGetMaterialCountResponse> GetMaterialCount()
        {
            return await _client.GetAsync<WXGetMaterialCountResponse>("cgi-bin/material/get_materialcount");
        }

        /// <summary>
        /// 获取永久素材列表
        /// </summary>
        /// <param name="type">素材类型</param>
        /// <param name="offset">从全部素材的该偏移位置开始返回，0表示从第一个素材 返回</param>
        /// <param name="count">返回素材的数量，取值在1到20之间</param>
        /// <returns></returns>
        public async Task<WXGetMaterialListResponse> GetMaterialList(MaterialTypeEnum type, int offset, int count)
        {
            string typeName = materialTypeMapper[type];
            return await _client.PostAsync<WXGetMaterialListResponse>("cgi-bin/material/batchget_material",
                new
                {
                    type = typeName,
                    offset,
                    count
                });
        }
        
        /// <summary>
        /// 获取素材详情
        /// </summary>
        /// <param name="mediaId">素材Id</param>
        /// <returns></returns>
        public async Task<WXGetMaterialResponse> GetMaterial(string mediaId)
        {
            HttpResponseMessage response = await _client.PostAsync<HttpResponseMessage>(
                "cgi-bin/material/get_material", new
                {
                    media_id = mediaId
                });
            if (response.Content.Headers.ContentType.MediaType == "text/plain")
            {
                return await response.GetObjectAsync<WXGetMaterialResponse>();
            }
            else
            {
                WXGetMaterialResponse r = new WXGetMaterialResponse();
                r.Stream = await response.Content.ReadAsStreamAsync();
                return r;
            }
        }
    }
}
