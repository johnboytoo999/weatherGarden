using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    /// <summary>
    /// controller共用邏輯
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {

        public class ApiResponse
        {
            /// <summary>
            /// 狀態碼
            /// </summary>
            public int StatusCode { get; set; }

            /// <summary>
            /// 是否成功
            /// </summary>
            public bool IsSuccess { get; set; }

            /// <summary>
            /// 回傳訊息
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Message { get; }

            /// <summary>
            /// Initial
            /// </summary>
            /// <param name="statusCode"></param>
            /// <param name="isSuccess"></param>
            /// <param name="message"></param>
            public ApiResponse(int statusCode, bool isSuccess, string message = null)
            {
                this.StatusCode = statusCode;
                this.IsSuccess = isSuccess;
                this.Message = message ?? GetDefaultMessageForStatus(statusCode);
            }

            private static string GetDefaultMessageForStatus(int statusCode)
            {
                switch (statusCode)
                {
                    case 200:
                        return "操作成功";
                    case 404:
                        return "查無資源";
                    case 500:
                        return "伺服器錯誤";
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// 成功回傳
        /// </summary>
        public class ApiOkResponse : ApiResponse
        {
            public object Data { get; }

            public ApiOkResponse(object result)
                : base(200, true)
            {
                Data = result;
            }
        }

        /// <summary>
        /// 失敗回傳
        /// </summary>
        public class ApiBadRequestResponse : ApiResponse
        {
            public IEnumerable<string> Errors { get; }

            /// <summary>
            /// For Model Validate
            /// </summary>
            /// <param name="modelState"></param>
            public ApiBadRequestResponse(ModelStateDictionary modelState)
                : base(400, false, "欄位驗證失敗")
            {
                if (modelState.IsValid)
                {
                    throw new ArgumentException("ModelState must be invalid", nameof(modelState));
                }

                this.Errors = modelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToArray();
            }

            /// <summary>
            /// For message
            /// </summary>
            /// <param name="message"></param>
            public ApiBadRequestResponse(string message)
                : base(400, false, message)
            {
                
            }
        }

        

        /// <summary>
        /// 成功回傳
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="message">訊息</param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public OkObjectResult SuccessResponse(object data = null, string message = "操作成功")
        {
            ApiOkResponse response = new ApiOkResponse(data);
            return Ok(response); // 回傳200
        }

        /// <summary>
        /// 失敗回傳訊息
        /// </summary>
        /// <param name="message">訊息</param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public BadRequestObjectResult FailResponse(string message)
        {
            ApiBadRequestResponse response = new ApiBadRequestResponse(message);
            return BadRequest(response); // 回傳400
        }

        /// <summary>
        /// 欄位驗證失敗回傳
        /// </summary>
        /// <param name="modelState">欄位驗證Object</param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public BadRequestObjectResult FailResponse(ModelStateDictionary modelState)
        {
            ApiBadRequestResponse response = new ApiBadRequestResponse(modelState);
            return BadRequest(response); // 回傳400
        }

        /// <summary>
        /// ApiValidationAttribute
        /// 有檢核的Action要加上此Attribute
        /// </summary>
        public class ApiValidationAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    context.Result = new BadRequestObjectResult(new ApiBadRequestResponse(context.ModelState));
                }

                base.OnActionExecuting(context);
            }
        }
    }
}