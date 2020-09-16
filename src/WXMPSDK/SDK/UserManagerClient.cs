using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    /// <summary>
    /// 用户管理接口
    /// </summary>
    public class UserManagerClient
    {
        private HttpClient _client;
        public UserManagerClient(HttpClient client)
        {
            _client = client;
            if(_client.BaseAddress == null)
            {
                _client.BaseAddress = WXConstants.WXMPApiUrl;
            }
        }

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<WXCreateTagResponse> CreateTag(string name)
        {
            return await _client.PostAsync<WXCreateTagResponse>("cgi-bin/tags/create", new
            {
                tag = new
                {
                    name = name
                }
            });
        }

        /// <summary>
        /// 获取公众号已创建的标签
        /// </summary>
        /// <returns></returns>
        public async Task<WXGetTagsResponse> GetTags()
        {
            return await _client.GetAsync<WXGetTagsResponse>("cgi-bin/tags/get");
        }

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="id">标签id</param>
        /// <param name="name">标签名称</param>
        /// <returns></returns>
        public async Task<WXResponse> UpdateTag(int id, string name)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/tags/update", new
            {
                tag = new
                {
                    id = id,
                    name = name
                }
            });
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="id">标签Id</param>
        /// <returns></returns>
        public async Task<WXResponse> DeleteTag(int id)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/tags/delete", new
            {
                tag = new
                {
                    id = id
                }
            });
        }

        /// <summary>
        /// 获取标签下粉丝列表
        /// </summary>
        /// <param name="tagId">标签Id</param>
        /// <param name="nextOpenId">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <returns></returns>
        public async Task<WXGetTagOpenIdResponse> GetTagOpenIds(int tagId, string nextOpenId = null)
        {
            return await _client.PostAsync<WXGetTagOpenIdResponse>("cgi-bin/user/tag/get",
                new
                {
                    tagid = tagId,
                    next_openid = string.IsNullOrEmpty(nextOpenId) ? null : nextOpenId
                });
        }

        /// <summary>
        /// 批量为用户打标签
        /// </summary>
        /// <param name="tagId">标签Id</param>
        /// <param name="openIds">OpenId列表</param>
        /// <returns></returns>
        public async Task<WXResponse> BatchTagging(int tagId, List<string> openIds)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/tags/members/batchtagging",
                new
                {
                    openid_list = openIds,
                    tagid = tagId
                });
        }

        /// <summary>
        /// 批量为用户取消标签
        /// </summary>
        /// <param name="tagId">标签Id</param>
        /// <param name="openIds">OpenId列表</param>
        /// <returns></returns>
        public async Task<WXResponse> BatchUnTagging(int tagId, List<string> openIds)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/tags/members/batchuntagging",
                new
                {
                    openid_list = openIds,
                    tagid = tagId
                });
        }

        /// <summary>
        /// 获取用户身上的标签列表
        /// </summary>
        /// <param name="openId">openId</param>
        /// <returns></returns>
        public async Task<WXGetUserTagListResponse> GetUserTags(string openId)
        {
            return await _client.PostAsync<WXGetUserTagListResponse>("cgi-bin/tags/getidlist",
                new
                {
                    openid = openId
                });
        }

        /// <summary>
        /// 对指定用户设置备注名
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public async Task<WXResponse> RemarkUser(string openid, string remark)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/user/info/updateremark",
                new
                {
                    openid = openid,
                    remark = remark
                });
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public async Task<WXGetUserInfoResponse> GetUserInfo(string openId, string lang)
        {
            NameValueCollection qs = new NameValueCollection()
            {
                { "openid", openId }
            };
            if (!string.IsNullOrEmpty(lang))
            {
                qs.Add("lang", lang);
            }
            return await _client.GetAsync<WXGetUserInfoResponse>("cgi-bin/user/info", qs);
        }

        /// <summary>
        /// 批量获取用户基本信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WXGetUserInfoListResponse> GetUserInfoList(WXBatchGetUserInfoRequest request)
        {
            return await _client.PostAsync<WXGetUserInfoListResponse>("cgi-bin/user/info/batchget", request);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="nextOpenId"></param>
        /// <returns></returns>
        public async Task<WXGetUserListResponse> GetUserList(string nextOpenId=null)
        {
            NameValueCollection qs = new NameValueCollection();
            if (!string.IsNullOrEmpty(nextOpenId))
            {
                qs.Add("next_openid", nextOpenId);
            }
            return await _client.GetAsync<WXGetUserListResponse>("cgi-bin/user/get", qs);
        }

        /// <summary>
        /// 获取公众号的黑名单列表
        /// </summary>
        /// <param name="nextOpenId"></param>
        /// <returns></returns>
        public async Task<WXGetUserListResponse> GetBlackUserList(string nextOpenId = null)
        {
            return await _client.PostAsync<WXGetUserListResponse>("cgi-bin/tags/members/getblacklist",
                new
                {
                    begin_openid=nextOpenId
                });
        }

        /// <summary>
        /// 拉黑用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WXResponse> BatchBlacklist(WXBatchBlacklistRequest request)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/tags/members/batchblacklist", request);
        }

        /// <summary>
        /// 取消拉黑
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WXResponse> BatchUnBlacklist(WXBatchBlacklistRequest request)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/tags/members/batchunblacklist", request);
        }
    }
}
