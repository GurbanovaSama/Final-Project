using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
