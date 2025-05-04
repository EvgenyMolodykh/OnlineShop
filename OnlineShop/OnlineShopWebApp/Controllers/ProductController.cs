using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Db.Interface;
using OnlineShopWebApp.Interface;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;

		public ProductController(IProductsRepository productRepository)
		{
			this.productRepository = productRepository;
		}

        public IActionResult Index(Guid id)
        {
           var product = productRepository.TryGetById(id);
           return View(product);
        }

        public IActionResult viewCatuselDetail() 
        {
            var products = productRepository.GetAll();
            return View(products);
        }
    }
}
