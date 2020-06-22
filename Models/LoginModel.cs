using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

namespace WebApi.Models
{
    /// <summary>
    /// �n�JRequest Model
    /// </summary>
    public class LoginRequest : BaseModel
    {
        /// <summary>
        /// �b��
        /// </summary>
        [Required(ErrorMessage = ValidationMessage.NotNull)]
        public string Account { get; set; }

        /// <summary>
        /// �K�X
        /// </summary>
        [Required(ErrorMessage = ValidationMessage.NotNull)]
        public string Password { get; set; }
    }

    /// <summary>
    /// �n�JResponse Model
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// User Data
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// JWT TOKEN
        /// </summary>
        public string Token { get; set; }
    }

    public class UserBag
    {
        [Required]
        public int userId { get; set; }

        [Required]
        public List<BagItem> BagItem { get; set; }
    }
    public class BagItem : ShopItem
    {
        [Required]
        public int Quantity { get; set; }
    }


}