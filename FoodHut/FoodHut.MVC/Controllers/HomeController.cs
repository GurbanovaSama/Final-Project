using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
