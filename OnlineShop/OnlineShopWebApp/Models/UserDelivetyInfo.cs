using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDelivetyInfo
    {
		[Required(ErrorMessage = "Заполните имя")]
		
		public string Name { get; set; }

		[Required(ErrorMessage = "Заполните адрес")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Заполните телефон")]
		[RegularExpression(@"^(\+7\d{10}|8\d{10})$", ErrorMessage = "Номер телефона должен начинаться с +7 или 8 и состоять из 11 цифр.")]
		public string Phone { get; set; }
    }
}
