using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Repository
{
    public class InMemoryUsersManager : IUsersManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAll()
        {
            return users;
        }

        public void Add(UserAccount user)
        {
            users.Add(user);
        }

        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(UserAccount user)
        {
            users.Remove(user);
        }

        public void ChangePassword(string userName, string newPassword)
        {
            var account = TryGetByName(userName);
            account.Password = newPassword;
        }

        public void UpdateUser(UserAccount userAccounts, UserAccount modifiedUserAccount)
        {
            userAccounts.Name = modifiedUserAccount.Name;
            userAccounts.LastName = modifiedUserAccount.LastName;
            userAccounts.Phone = modifiedUserAccount.Phone;
        }

        public void DeleteAccount(UserAccount userAccounts)
        {
           users.Remove(userAccounts);
        }
    }
}
