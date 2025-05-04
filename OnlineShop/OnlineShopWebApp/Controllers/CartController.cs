using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Db.Interface;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
		private readonly ICartsRepository cartsRepository;

		public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository)
		{
			this.productsRepository = productRepository;
			this.cartsRepository = cartsRepository;
		}

        public IActionResult Index(string id)
         {
           	var cart = cartsRepository.TryGetByUserId(Constants.UserId); 
            return View(cart);
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            var productViewModel = new ProductViewModel
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };

            cartsRepository.Add(productViewModel, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(Guid productGuid)
        {
            cartsRepository.DecreaseAmount(productGuid, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear() 
        
        {
            cartsRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");

        }
    }
}
