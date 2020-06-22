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
    public class UsersController : BaseApiController
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/users/authenticate
        ///     {
        ///        "account": "sam",
        ///        "password": "123456"
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>返回使用者資訊以及Token</returns>
        /// <response code="200">返回使用者資訊以及Token</response>
        /// <response code="400">找不到該使用者</response>
        [ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiBadRequestResponse), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [ApiValidation]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginRequest model)
        {
            var result = _userService.Authenticate(model.Account, model.Password);

            if (result.User == null)
                return FailResponse("帳號或密碼錯誤");

            return SuccessResponse(result);
        }


        /// <summary>
        /// 取得背包列表
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/users/bag/3
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <param name="userId">使用者Id</param>
        /// <response code="200">返回使用者背包列表</response>
        [ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiBadRequestResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("bag/{userid}")]
        public IActionResult getBagList(int userId)
        {
            var result = _userService.GetBagList(userId);

            return SuccessResponse(result);
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return SuccessResponse(users);
        //}


        /// <summary>
        /// 爬蟲中央氣象局網站之臺北目前天氣
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/users/weather
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        [HttpGet("weather")]
        public IActionResult GetWeather()
        {
            string result = _userService.GetCurrentWeatherJson();
            return SuccessResponse(result);
        }
    }
}
