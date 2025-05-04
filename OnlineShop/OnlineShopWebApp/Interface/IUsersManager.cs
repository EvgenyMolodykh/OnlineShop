using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interface
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
        void Remove(UserAccount user);
        void ChangePassword(string userName, string newPassword);
        void UpdateUser(UserAccount userAccounts, UserAccount userAccount);
        void DeleteAccount(UserAccount userAccounts);
    }
}