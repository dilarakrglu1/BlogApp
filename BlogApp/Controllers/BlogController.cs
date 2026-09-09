using BlogApp.Entities;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBlogModel model)
        {
            Veritabani veritabani = new Veritabani();

            Blog blog = new Blog()
            {
                Title = model.Title,
                Content = model.Content,
                CreatedDate = DateTime.Now,
                UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
            };

            veritabani.Blogs.Add(blog);
            veritabani.SaveChanges();

            return RedirectToAction("GetAllByLoginUser");
        }

        [HttpGet]
        public IActionResult GetAllByLoginUser()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Veritabani veritabani = new Veritabani();

            List<Blog> blogs = veritabani.Blogs.Where(blog => blog.UserId == userId).ToList();

            return View(blogs);
        }

        [HttpGet]
        public IActionResult GetDetail(int id)
        {
            Veritabani veritabani = new Veritabani();
            Blog blog = veritabani.Blogs.FirstOrDefault(blog => blog.Id == id);

            return View(blog);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Veritabani veritabani = new Veritabani();

            Blog blog = veritabani.Blogs.FirstOrDefault(b => b.Id == id);

            if (blog != null)
            {
                veritabani.Blogs.Remove(blog);
                veritabani.SaveChanges();
            }

            return RedirectToAction("GetAllByLoginUser");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Veritabani veritabani = new Veritabani();

            Blog blog = veritabani.Blogs.FirstOrDefault(b => b.Id == id);

            UpdateBlogModel model = new UpdateBlogModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateBlogModel model)
        {
            Veritabani veritabani = new Veritabani();

            Blog blog = veritabani.Blogs.FirstOrDefault(b => b.Id == model.Id);

            blog.Title = model.Title;
            blog.Content = model.Content;

            veritabani.Update(blog);
            veritabani.SaveChanges();

            return RedirectToAction("GetAllByLoginUser");
        }
    }
}
