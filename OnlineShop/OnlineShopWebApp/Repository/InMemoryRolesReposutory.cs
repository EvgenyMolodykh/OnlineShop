using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Interface;

namespace OnlineShopWebApp.Repository
{
    public class InMemoryRolesReposutory : IRolsRepository
    {
        private readonly List<Role> roles = new List<Role>();
        public void Add(Role role)
        {
            roles.Add(role);
        }

        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }

    }
}
