using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CatBlog.Data;
using CatBlog.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CatBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly CatBlogContext _context;
        private readonly IConfiguration _config;

        public AdminController(CatBlogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: /Admin/Login
        [HttpGet]
        public IActionResult Login() => View();

        // POST: /Admin/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var adminUser = _config["AdminAccount:Username"];
            var adminPass = _config["AdminAccount:Password"];

            if (model.Username == adminUser && model.Password == adminPass)
            {
                HttpContext.Session.SetString("Admin", model.Username);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Admin");
            return RedirectToAction("Login");
        }

        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Admin") == null)
                return RedirectToAction("Login");

            var posts = _context.Posts.OrderByDescending(p => p.CreatedAt).ToList();
            return View(posts);
        }

        // GET: /Admin/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Admin") == null)
                return RedirectToAction("Login");

            return View(new Post());
        }

        // POST: /Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (HttpContext.Session.GetString("Admin") == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                post.CreatedAt = DateTime.Now;
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            return View(post);
        }

        // GET: /Admin/Edit/5
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
                return RedirectToAction("Login");

            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound();

            return View(post);
        }

        // POST: /Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (HttpContext.Session.GetString("Admin") == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                _context.Posts.Update(post);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(post);
        }

        // POST: /Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
                return RedirectToAction("Login");

            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }


    }
}
