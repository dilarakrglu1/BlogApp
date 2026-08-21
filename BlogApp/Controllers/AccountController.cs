using BlogApp.Entities;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login(LoginModel model)
        {
            Veritabani veritabani = new Veritabani();
            User user = veritabani.Users.First();
            if(model.Email== user.Email && model.Password == user.Password)
            {
                return RedirectToAction("Index", "Home");
            }
           else
            {
                return View(model);
            }
        }
    } 

}
