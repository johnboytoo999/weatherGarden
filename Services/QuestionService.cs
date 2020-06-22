using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static WebApi.Services.BaseService;

namespace WebApi.Services
{

    public class QuestionService : IQuestionService
    {

        private readonly AppSettings _appSettings;
        private readonly WeatherGardenContext _context;
        private readonly IMapper _mapper;

        public QuestionService(IOptions<AppSettings> appSettings, WeatherGardenContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }
   

        public ServiceResult GetAll(int userId)
        {
            var user = _context.User.SingleOrDefault(x => x.Id == userId);
            if (user == null)
                return ServiceResult.Fail("無此使用者");

            QuestionTypeList questionTypeList = new QuestionTypeList();
            var questionTypes = _context.QuestionType.Where(x => x.Education == user.Education).ToList();
            questionTypeList.Type = _mapper.Map<List<QuestionType>,List<QuestionTypeModel>>(questionTypes);
            return ServiceResult.Success("操作成功",questionTypeList);
        }

        /// <summary>
        /// 取得題目
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public ServiceResult GetQuestion(int typeId)
        {

            var questionList = _context.QuestionList.Where(x => x.Type == typeId);

            if(questionList.Count() == 0)
                return ServiceResult.Fail("題目取得失敗");

            QuestionModel questionModel = new QuestionModel();
            Random rand = new Random();

            //取得隨機號碼
            int toSkip = rand.Next(0, questionList.Count());
            var question = questionList.Skip(toSkip).Take(1).First();

            questionModel = _mapper.Map<QuestionList, QuestionModel>(question);
            return ServiceResult.Success("操作成功",questionModel);
        }

        /// <summary>
        /// 回答問題
        /// </summary>
        /// <param name="answerQuestion"></param>
        /// <returns></returns>
        public ServiceResult AnswerQuestion(AnswerQuestionModel answerQuestion)
        {
          
            var question = _context.QuestionList.SingleOrDefault(x => x.Id == answerQuestion.QuestionId);
            var user = _context.User.SingleOrDefault(x => x.Id == answerQuestion.UserId);

            if (question == null)
                return ServiceResult.Fail("題目取得失敗");
            if (user == null)
                return ServiceResult.Fail("無使用者");

            if (question.CorrectAnswer == answerQuestion.Answer)
            {
                user.Money += question.Reward;
                _context.SaveChanges();
                return ServiceResult.Success("答題成功", question.CorrectAnswer);
            }
            else
            {
                return ServiceResult.Fail("答題失敗", question.CorrectAnswer);
            }
                

                

        }
    }
}