using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            var productCounts = cart?.AmountCart ?? 0;
            return View("Cart", productCounts);

        }
    }
}
