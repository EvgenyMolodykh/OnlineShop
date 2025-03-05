using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization
{
    public class UserManagement
    {
        private static List<User> users = new List<User>();
        public static void AddUser(User user)
        {
            users.Add(user);
        }

        public static User GetUser(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        }

     
    }
}
