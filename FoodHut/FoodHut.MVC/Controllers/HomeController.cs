using FoodHut.BL.Services.Abstractions;
using FoodHut.BL.Services.Implementations;
using FoodHut.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHut.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly ICategoryService _categoryService;
        readonly IProductService _productService;
        readonly IReviewService _reviewService;
        readonly IRestaurantService _restaurantService;

        public HomeController(IProductService productService, ICategoryService categoryService, IReviewService reviewService, IRestaurantService restaurantService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _reviewService = reviewService;
            _restaurantService = restaurantService;
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
                // Burada restoran siyahısını doldururuq
                var restaurants = await _restaurantService.GetAllAsync();
                ViewData["Restaurants"] = new SelectList(restaurants, "Id", "Name");
                return View(VM);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }
    }
}
