using System.IO;
using System.Text.Json;

namespace Autorization
{
    public static class FileProvider
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
        public static void Save(object data, string fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            string serializedData = JsonSerializer.Serialize(data, options);
            if(File.Exists(fileName))
            {
                File.WriteAllText(fileName, serializedData);
            }
            else
            {
                File.Create(fileName).Close();
                File.WriteAllText(fileName, serializedData);
            }
        }
        public static T Load<T>(string fileName)
        {
            if (!File.Exists(fileName)) 
            {
                return default;
            }

            var serializedData = File.ReadAllText(fileName);

            if (string.IsNullOrEmpty(serializedData))
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(serializedData);
        }
    }
}
