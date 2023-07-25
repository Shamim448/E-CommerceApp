using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("name", "Name and Display order candot be same");
            }
            if(ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
