using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace FoodHut.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IRestaurantService _restaurantService;

        public ReviewController(IReviewService reviewService, IRestaurantService restaurantService)
        {
            _reviewService = reviewService;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var restaurants = await _restaurantService.GetAllAsync();
            ViewData["Restaurants"] = new SelectList(restaurants, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

          

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            await _reviewService.UserCreateAsync(dto,
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                User.Identity.Name,
                User.FindFirst(ClaimTypes.Role)?.Value
            );
            await _reviewService.SaveChangesAsync();

            TempData["SuccessMessage"] = "Your review has been submitted successfully!";
            return RedirectToAction("Index", "Home");
        }
    }
}
