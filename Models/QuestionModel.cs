using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    /// <summary>
    /// 商店Item
    /// </summary>
    public class QuestionTypeModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
       
        public int  Id{ get; set; }


        /// <summary>
        /// 名字
        /// </summary>        
        public string Type { get; set; }

    }

    public class QuestionTypeList
    {
        public List<QuestionTypeModel> Type { get; set; }
    }

    public class QuestionModel 
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public int Reward { get; set; }

        public string AnswerA { get; set; }

        public string AnswerB { get; set; }

        public string AnswerC { get; set; }

        public string AnswerD { get; set; }

        public string Source { get; set; }
    }

    public class AnswerQuestionModel : BaseModel
    {
        [Required(ErrorMessage = ValidationMessage.NotNull)]
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.GreaterThanZero)]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = ValidationMessage.NotNull)]
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.GreaterThanZero)]
        public int UserId { get; set; }

        [Required(ErrorMessage = ValidationMessage.NotNull)]  
        public string Answer { get; set; }
    }
}
