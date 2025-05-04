using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Interface;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;
        public AccountController(IUsersManager UsersManager)
        {
            this.usersManager = UsersManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            var userAccount = usersManager.TryGetByName(login.UserName);

            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует");
                return View(nameof(Login));
            }

            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Неправильный пароль");
                return View(nameof(Login));


            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (register.Name == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                usersManager.Add(
                    new Models.UserAccount
                    {
                        Name = register.Name,
                        Password = register.Password,
                        Email = register.Email,
                        Phone = register.Phone
                    });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(nameof(Register));
        }
    }
}
