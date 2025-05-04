using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository orderRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository orderRepository)
        {
            this.cartsRepository = cartsRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index() 
        {
         
            return View();
        }

        public IActionResult Buy()
        {
          return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Buy(UserDelivetyInfo user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            var order = new OrderViewModel
            {
                User = user,
                Items = existingCart.Items
            };
            orderRepository.Add(order);
            cartsRepository.Clear(Constants.UserId);
            return View();
        }

    }
}
