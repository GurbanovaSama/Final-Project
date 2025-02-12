using FoodHut.BL.Services.Abstractions;
using FoodHut.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly ICategoryService _categoryService;
        readonly IProductService _productService;
        readonly IReviewService _reviewService;

        public HomeController(IProductService productService, ICategoryService categoryService, IReviewService reviewService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                HomeVM VM = new()
                {
                    Categories = await _categoryService.GetCategoryViewItemsAsync(),
                    Products = await _productService.GetViewItemsAsync(),
                    Reviews = await  _reviewService.GetViewItemsAsync()   
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
