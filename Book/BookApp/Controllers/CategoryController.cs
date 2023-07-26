using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
            Category categoryFormdb  = _context.Categories.FirstOrDefault(n => n.Name == obj.Name || n.DisplayOrder == obj.DisplayOrder );
            if (categoryFormdb.Name == obj.Name || categoryFormdb.DisplayOrder == obj.DisplayOrder) {
                ModelState.AddModelError("", "Name or  Displayorder can not be duplicate");
            }
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

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) { 
                return NotFound();
            }
            Category obj = _context.Categories.FirstOrDefault(i => i.Id == id);
            Category obj1 = _context.Categories.Find(id);
            Category obj2 = _context.Categories.Where(i => i.Id == id).FirstOrDefault();
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _context.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category? obj = _context.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
