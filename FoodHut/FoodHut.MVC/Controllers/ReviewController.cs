using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewCreateDto reviewCreateDto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            reviewCreateDto.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            reviewCreateDto.UserName = User.Identity.Name;
            reviewCreateDto.UserRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (!ModelState.IsValid)
            {
                return View(reviewCreateDto);
            }

            await _reviewService.CreateAsync(reviewCreateDto);
            await _reviewService.SaveChangesAsync();

            TempData["SuccessMessage"] = "Your review has been submitted successfully!";
            return RedirectToAction("Index", "Home");
        }
    }
}
