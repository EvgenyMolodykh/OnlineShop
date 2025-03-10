using System.Collections.Generic;
using System.Linq;

namespace Autorization
{
    public class UserStorage
    {
        public const string fileName = "users.json";  
        public void Add(User user)
        {
            var users = GetAllUsers();
            users.Add(user);
            FileProvider.Save(users, fileName);
        }
        public User GetSingInUser()
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(u => u.IsSingIn);
        }
        public void SingOut()
        {
            var singInUser = GetSingInUser();
            if (singInUser != null)
            {
                var users = GetAllUsers();
                var existingSingInUser = users.FirstOrDefault(u => u.Login == singInUser.Login && u.Password == singInUser.Password);
                existingSingInUser.IsSingIn = false;
                FileProvider.Save(users, fileName);
            }
        }
        private static List<User> GetAllUsers()
        {
            return FileProvider.Load<List<User>>(fileName) ?? new List<User>();
        }
    }
}
