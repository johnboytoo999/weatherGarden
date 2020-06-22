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
    public class QuestionController : BaseApiController
    {
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /// <summary>
        /// 取得題目類型
        /// </summary>
        /// <returns>返回題目類型</returns>
        [ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
        [HttpGet("getAllType/{userId}")]
        public IActionResult GetAll(int userId)
        {
            var result = _questionService.GetAll(userId);

            if (result.Status)
                return SuccessResponse(result);
            else
                return FailResponse(result.Message);
        }


        /// <summary>
        /// 取得題目
        /// </summary>
        /// <param name="typeId">取得題目</param>
        /// <response code="200">取得題目</response>
        [ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiBadRequestResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("getQuestion/{typeId}")]
        public IActionResult GetQuestion(int typeId)
        {
            var result = _questionService.GetQuestion(typeId);

            if(result.Status)
            return SuccessResponse(result);
            else
            return FailResponse(result.Message);
        }

        /// <summary>
        /// 回答問題
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/shop/answer
        ///     {
        ///      "QuestionId":1,
        ///      "UserId": 3,
        ///      "Answer":"A"
        ///     }
        ///
        /// </remarks>
        /// <param name="answerQuestion"></param>
        /// <returns></returns>
        /// <response code="200">回傳達題結果</response>
        /// <response code="400">API錯誤</response>
        [HttpPost("answer")]
        [ApiValidation]
        public IActionResult AnswerQuestion(AnswerQuestionModel answerQuestion)
        {
            var result = _questionService.AnswerQuestion(answerQuestion);

            if (result.Data != null)
                return SuccessResponse(result,result.Message);
            else
                return FailResponse(result.Message);
              

        }
    }
}
