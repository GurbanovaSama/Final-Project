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
                return View(dto);
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
