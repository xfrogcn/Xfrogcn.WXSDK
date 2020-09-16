using System;
using System.Net.Http;
using System.Threading.Tasks;
using WXMPSDK.Dto;

namespace WXMPSDK
{
    public class MenuClient
    {
        private HttpClient _client;
        public MenuClient(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public async Task<WXResponse> CreateMenu(WXMenuDefine menu)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/menu/create", menu);
        }

        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <returns></returns>
        public async Task<WXMenuResponse> GetCurrentSelfMenuInfo()
        {
            return await _client.GetAsync<WXMenuResponse>("cgi-bin/get_current_selfmenu_info");
        }

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <returns></returns>
        public async Task<WXResponse> DeleteMenu()
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/menu/delete", null, HttpMethod.Delete.Method);
        }

        /// <summary>
        /// 创建个性化菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public async Task<WXConditionalMenuResponse> CreateConditionMenu(WXMenuDefine menu)
        {
            return await _client.PostAsync<WXConditionalMenuResponse>("cgi-bin/menu/addconditional", menu);
        }

        /// <summary>
        /// 删除个性化菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task<WXResponse> DeleteConditionMenu(string menuId)
        {
            return await _client.PostAsync<WXResponse>("cgi-bin/menu/delconditional", new
            {
                menuid = menuId
            });
        }

        /// <summary>
        /// 测试个性化菜单匹配结果
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<WXTryMatchConditionMenuResponse> TryMatch(string userId)
        {
            return await _client.PostAsync<WXTryMatchConditionMenuResponse>(
                "cgi-bin/menu/trymatch", new
                {
                    user_id = userId
                });
        }
    }
}
