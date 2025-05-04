using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage = "Заполните почту")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Заполните имя")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Заполните фамилию")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Заполните пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Заполните телефон")]
        public string Phone {  get; set; }

    }
}
