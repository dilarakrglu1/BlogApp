using BlogApp.Entities;
using BlogApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            Veritabani veritabani = new Veritabani();
            User user = veritabani.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CreateUserModel model)
        {
            Veritabani veritabani = new Veritabani();

            bool varmi = veritabani.Users.Any(u => u.Username == model.Username || u.Email == model.Email);

            if (varmi)
            {
                ModelState.AddModelError("", "Sistemde zaten bu bilgilerle aynı kullanıcı mevcuttur.");
                return View();
            }
            else
            {
                User user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    CreatedDate = DateTime.Now
                };

                veritabani.Users.Add(user);
                veritabani.SaveChanges();

                return RedirectToAction("Login", "Account");
            }
        }
    }

}
