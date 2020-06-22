using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;
using static WebApi.Services.BaseService;

namespace WebApi.Services.Interfaces
{
    public interface IShopService
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        /// <returns></returns>
        ShopInformation GetShopList();

        /// <summary>
        /// 購買商店物品
        /// </summary>
        /// <param name="buyItemRequest"></param>
        /// <returns></returns>

        ServiceResult BuyItem(BuyItemRequest buyItemRequest);
    }
}
