using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class BaseService
    {
        public class ServiceResult
        {
            /// <summary>
            /// 狀態
            /// </summary>
            public bool Status { get; set; }

            /// <summary>
            /// 訊息
            /// </summary>

            public string Message { get; set; }

            /// <summary>
            /// 資料
            /// </summary>

            public object Data { get; set; } = null;


            /// <summary>
            /// 建構式
            /// </summary>
            public ServiceResult(bool status, string message, object data = null)
            {
                this.Status = status;
                this.Message = message;
                this.Data = data;
            }

            /// <summary>
            /// 成功回傳
            /// </summary>
            /// <param name="message">成功訊息</param>
            /// <param name="data"></param>
            public static ServiceResult Success(string message = "操作成功", object data = null)
            {
                return new ServiceResult(true, message, data);
            }

            /// <summary>
            /// 失敗回傳
            /// </summary>
            /// <param name="message">失敗訊息</param>
            /// <param name="data">回傳資料</param>
            public static ServiceResult Fail(string message, object data = null)
            {
                return new ServiceResult(false, message, data);
            }
        }
    }
}
