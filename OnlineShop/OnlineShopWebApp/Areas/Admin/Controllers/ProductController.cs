using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Db.Interface;
using OnlineShopWebApp.Enums;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public ProductController(IProductsRepository productRepository)
        {
            productsRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            var productsViewModel = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    ImagePath = product.ImagePath,
                    Cost = product.Cost,
                    Description = product.Description,
                    Name = product.Name
                };

                productsViewModel.Add(productViewModel);
            }
            
            return View(productsViewModel);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product 
            { 
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };

            productsRepository.Add(productDb);
            return RedirectToAction("Index");
        }

        public IActionResult EditProduct(Guid productGuid)
        {
            var products = productsRepository.TryGetById(productGuid);
            return View(products);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };

            productsRepository.Update(productDb);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            productsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
