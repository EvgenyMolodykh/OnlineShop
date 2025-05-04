using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;
        public UserController(IUsersManager usersManager)
        {
           this.usersManager = usersManager;
        }
        public IActionResult Index()
        {
            var userAccounts = usersManager.GetAll();
            return View(userAccounts);
        }

        
        public IActionResult Details(string name) 
        {
            var userAccounts = usersManager.TryGetByName(name);
            return View(userAccounts);
        }

        public IActionResult ChangePassword(string name)
        {
            
            var changePassword = new ChangePassword()
            {
                UserName = name
            };      
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword newPassword)
        {
            
            if (newPassword == null)
            {
                ModelState.AddModelError("", "Не удалось получить данные из формы. Проверьте, были ли они отправлены.");
                return View();
            }

            if (newPassword.UserName == newPassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не могут совпадать");
            }
            if (ModelState.IsValid)
            {
                usersManager.ChangePassword(newPassword.UserName, newPassword.Password);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }

        public IActionResult EditUser(string name)
        {
            var userAccounts = usersManager.TryGetByName(name);
            return View(userAccounts);
        }

        [HttpPost]
        public IActionResult EditUser(UserAccount userAccount, string name)
        {
            if (string.IsNullOrEmpty(userAccount.Name))
            {
                ModelState.AddModelError("Name", "Имя обязательно для заполнения.");
            }

            if (string.IsNullOrEmpty(userAccount.LastName))
            {
                ModelState.AddModelError("LastName", "Фамилия обязательна для заполнения.");
            }

            if (string.IsNullOrEmpty(userAccount.Phone))
            {
                ModelState.AddModelError("Phone", "Телефон обязателен для заполнения.");
            }

            var existingUser = usersManager.TryGetByName(name);
            usersManager.UpdateUser(existingUser, userAccount);
            return RedirectToAction("Index", "User");
        }

        public IActionResult DeleteUser(string name)
        {
            var userAccounts = usersManager.TryGetByName(name);
            usersManager.DeleteAccount(userAccounts);
            return RedirectToAction("Index", "User");
        }


    }
}
