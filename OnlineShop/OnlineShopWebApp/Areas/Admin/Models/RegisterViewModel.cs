using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Заполните логин")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните пароль")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен содержать от 6 до 20 символов.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пароль не совпадает")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен содержать от 6 до 20 символов.")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают. Пожалуйста, попробуйте еще раз.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Заполните почту")]
        [EmailAddress(ErrorMessage = "Введите корректный адрес электронной почты.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Заполните телефон")]
        public string Phone { get; set; }
    }
}
