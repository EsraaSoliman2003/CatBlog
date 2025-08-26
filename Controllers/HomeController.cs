using Microsoft.AspNetCore.Mvc;
using CatBlog.Data;
using CatBlog.Models;
using System.Linq;

namespace CatBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly CatBlogContext _context;

        public HomeController(CatBlogContext context)
        {
            _context = context;
        }

        // GET: /Home/Index
        public IActionResult Index()
        {
            var posts = _context.Posts.OrderByDescending(p => p.CreatedAt).ToList();
            return View(posts);
        }

        // GET: /Home/Details/5
        public IActionResult Details(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound();
            return View(post);
        }
    }
}
