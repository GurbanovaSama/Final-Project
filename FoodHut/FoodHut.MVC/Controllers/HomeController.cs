using FoodHut.BL.Services.Abstractions;
using FoodHut.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly ICategoryService _categoryService;
        readonly IProductService _productService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                HomeVM VM = new()
                {
                    Categories = await _categoryService.GetCategoryViewItemsAsync(),
                    Products = await _productService.GetViewItemsAsync()
                };

                return View(VM);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }
    }
}
