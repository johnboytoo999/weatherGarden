using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class BaseModel
    {
        /// <summary>
        /// 欄位驗證錯誤訊息
        /// </summary>
        protected class ValidationMessage
        {
            public const string NotNull = "{0} 不能為空白";

            public const string GreaterThanZero = "{0} 必須大於0";
        }
    }
}
