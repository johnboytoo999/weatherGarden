using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Models;
using System.Linq;
using WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    /// <summary>
    /// 有Authorize attribute代表要帶token才可以呼叫
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HandbookController : BaseApiController
    {
        private IHandbookService _handbookService;

        public HandbookController(IHandbookService handbookService)
        {
            _handbookService = handbookService;
        }


        /// <summary>
        /// 取得圖鑑列表
        /// </summary>
        /// <remarks>
        /// 圖鑑數量為0表示未解鎖
        /// Sample request:
        ///
        ///     GET /api/Handbook/User/3
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <param name="userId">使用者Id</param>
        /// <response code="200">返回使用者圖鑑列表</response>
        [ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiBadRequestResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("User/{userId}")]
        public IActionResult UserHandbook(int userId)
        {
            var result = _handbookService.UserHandbook(userId);

            if(result.Status)
                return SuccessResponse(result);
            else
                return FailResponse(result.Message);
        }

    }
}
