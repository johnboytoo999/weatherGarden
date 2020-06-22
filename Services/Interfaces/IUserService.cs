using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 回傳登入者資料和JWT TOKEN
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        LoginResponse Authenticate(string account, string password);


        /// <summary>
        /// 取得背包列表
        /// </summary>
        /// <param name="userId">使用者ID</param>
        /// <returns></returns>
        UserBag GetBagList(int userId);

        /// <summary>
        /// 取得全部使用者
        /// </summary>
        /// <returns></returns>
        List<User> GetAll();

        /// <summary>
        /// 爬蟲中央氣象局網站取得目前天氣的JSON字串
        /// </summary>
        /// <returns></returns>
        String GetCurrentWeatherJson();
    }
}
