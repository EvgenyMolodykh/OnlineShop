using OnlineShop.Db.Models;
namespace OnlineShopWebApp.Db.Interface
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(Guid id);
        void Add( Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}