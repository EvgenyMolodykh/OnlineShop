namespace Autorization
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConformPassword { get; set; }

        public User(string login, string password, string conformPassword) 
        {
            this.Id = Guid.NewGuid();
            this.Login = login;
            this.Password = password;
            this.ConformPassword = conformPassword;
        }
       
    }
}
