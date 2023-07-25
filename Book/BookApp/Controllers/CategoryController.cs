using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
