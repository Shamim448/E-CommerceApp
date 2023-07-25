using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
           List<Category> getAllCatagories = _context.Categories.ToList();
            return View(getAllCatagories);
        }
    }
}
