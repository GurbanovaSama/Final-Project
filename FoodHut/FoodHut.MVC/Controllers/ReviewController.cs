using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewCreateDto reviewCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(reviewCreateDto);
            }

            await _reviewService.CreateAsync(reviewCreateDto);
            await _reviewService.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
