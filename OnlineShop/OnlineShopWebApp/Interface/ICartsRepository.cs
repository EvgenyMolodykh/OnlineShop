using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interface
{
    public interface ICartsRepository
    {
        void Add(ProductViewModel product, string userId);
        void Clear(string userId);
        void DecreaseAmount(Guid productGuid, string userId);
        Cart TryGetByUserId(string userId);
    }
}