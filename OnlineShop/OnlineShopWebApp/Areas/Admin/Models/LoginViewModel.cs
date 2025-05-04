using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Заполните логин")]
       
        public string UserName { get; set; }
        [Required(ErrorMessage = "Заполните пароль")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен содержать от 6 до 20 символов.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
