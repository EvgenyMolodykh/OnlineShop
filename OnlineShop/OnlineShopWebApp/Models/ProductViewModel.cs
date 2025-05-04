using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Заполните имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните цену")]
        [Range(0,1000000, ErrorMessage = "Цена должна быть в пределах от 0 до 1000000 руб.")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Заполните описание")]
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
