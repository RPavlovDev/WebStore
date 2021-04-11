using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly ILogger<AccountController> _Logger;

        public AccountController(
            UserManager<User> UserManager,
            SignInManager<User> SignInManager,
            ILogger<AccountController> Logger)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _Logger = Logger;
        }

        [AllowAnonymous]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);

            var user = new User
            {
                UserName = Model.Email
            };
            _Logger.LogInformation("Регистрация пользователя {0}", user.UserName);

            var registration_result = await _UserManager.CreateAsync(user, Model.Password);
            if (registration_result.Succeeded)
            {
                _Logger.LogInformation("Пользователь {0} успешно зарегистрирован", user.UserName);

                await _UserManager.AddToRoleAsync(user, Role.Users);

                _Logger.LogInformation("Пользователь {0} наделён ролью {1}", user.UserName, Role.Users);

                await _SignInManager.SignInAsync(user, false);

                _Logger.LogInformation("Пользователь {0} вошёл в систему сразу после регистрации", user.UserName);

                return RedirectToAction("Index", "Home");
            }

            _Logger.LogWarning("Ошибка при регистрации пользователя {0}: {1}",
                user.UserName,
                string.Join(",", registration_result.Errors.Select(e => e.Description)));

            foreach (var error in registration_result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(Model);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login(string returnUrl) => View(new LoginViewModel() { ReturnUrl = returnUrl });

        [HttpPost]
        [ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);

            var login_result = await _SignInManager.PasswordSignInAsync(
                Model.Email,
                Model.Password,
                Model.RememberMe,
#if DEBUG
                false
#else
                true
#endif
            );

            if (login_result.Succeeded)
            {
                _Logger.LogInformation("Пользователь {0} вошёл в систему", Model.Email);

                //if (Url.IsLocalUrl(Model.ReturnUrl))
                //    return Redirect(Model.ReturnUrl);
                //return RedirectToAction("Index", "Home");
                return LocalRedirect(Model.ReturnUrl ?? "/");
            }

            _Logger.LogWarning("Ошибка при вводе имени пользователя {0} либо пароля", Model.Email);

            ModelState.AddModelError("", "Неверное имя пользователя, или пароль!");
            return View(Model);
        }
        public IActionResult AccessDenied(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            var user_name = User.Identity!.Name;
            await _SignInManager.SignOutAsync();

            _Logger.LogInformation("Пользователь {0} вышел из системы", user_name);

            return RedirectToAction("Index", "Home");
        }

    }
}
