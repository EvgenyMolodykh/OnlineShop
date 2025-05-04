using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Interface
{
    public interface IRolsRepository
    {
        
        List<Role> GetAll();
        Role TryGetByName(string Name);
        void Add( Role role);
        void Remove(string name);
    }
}