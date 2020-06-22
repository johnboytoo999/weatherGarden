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
    public class ShopItem
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
        /// 價格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 圖片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 成長難度
        /// </summary>
        public int Growing { get; set; }

        /// <summary>
        /// 節氣
        /// </summary>
        public string SolarTerms { get; set; }
    }

    public class ShopInformation
    {
        public List<ShopItem> ShopItems { get; set; }

        public string SolarTerms { get; set; }

        public string DayDescription { get; set; }

        public string Description { get; set; }

    }

    public class BuyItemRequest : BaseModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Required(ErrorMessage = ValidationMessage.NotNull)]
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.GreaterThanZero)]
        public int UserId { get; set; }

        /// <summary>
        /// 產品ID
        /// </summary>
        [Required(ErrorMessage = ValidationMessage.NotNull)]
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.GreaterThanZero)]
        public int ProductId { get; set; }

        /// <summary>
        /// 數量
        /// </summary>

        [Required(ErrorMessage = ValidationMessage.NotNull)]
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.GreaterThanZero)]
        public int Quantity { get; set; }

    }
}
