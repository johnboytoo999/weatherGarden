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
    public class HandbookModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int  Id{ get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 圖片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 成長難度
        /// </summary>
        public string Notice { get; set; }

        /// <summary>
        /// 節氣
        /// </summary>
        public string SolarTerms { get; set; }

        /// <summary>
        /// 節氣描述
        /// </summary>
        public string SolarTermsDate { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int  PlantCount { get; set; }
    }


}
