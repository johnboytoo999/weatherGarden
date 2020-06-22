using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Models;
using System.Linq;
using WebApi.Services.Interfaces;


namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : BaseApiController
    {
        private IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        /// <summary>
        /// 取得商店列表
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/shop
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">取得物品列表</response>
        [HttpGet]
        public IActionResult GetShopList()
        {
            var result = _shopService.GetShopList();

            return SuccessResponse(result);
        }


        /// <summary>
        /// 購買物品
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/shop/buy
        ///     {
        ///        "UserId": 3,
        ///        "ProductId": 1,
        ///        "Quantity": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="buyItemRequest"></param>
        /// <returns></returns>
        /// <response code="200">購買成功</response>
        /// <response code="400">購買失敗</response>
        [HttpPost("buy")]
        [ApiValidation]
        public IActionResult BuyItem(BuyItemRequest buyItemRequest)
        {
            var buyItemResult = _shopService.BuyItem(buyItemRequest);

            if(buyItemResult.Status)
                return SuccessResponse();
            else
                return FailResponse(buyItemResult.Message);

        }
    }
}
