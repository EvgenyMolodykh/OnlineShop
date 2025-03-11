namespace Autorization
{
    public class UserStorage
    {
        public const string fileName = "users.json";
        private static List<User> users = GetAllUsers();

        public static User GetUser(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        }
        public void Add(User user)
        {
            users.Add(user);
            FileProvider.Save(users, fileName);
        }
        public User GetSingInUser()
        {
          
            return users.FirstOrDefault(u => u.IsSingIn);
        }
        public void SingOut()
        {
            var singInUser = GetSingInUser();
            if (singInUser != null)
            {
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
