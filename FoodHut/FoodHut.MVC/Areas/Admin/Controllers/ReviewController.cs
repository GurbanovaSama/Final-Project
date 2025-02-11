using FoodHut.BL.DTOs;
using FoodHut.BL.Exceptions;
using FoodHut.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            ICollection<ReviewListItemDto> reviews = await _reviewService.GetAllAsync();
            return View(reviews);
        }

        //DETAILS
        public async Task<IActionResult> Details(int id)
        {
            ReviewViewItemDto? review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }


        //CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewCreateDto reviewCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(reviewCreateDto);
            }

            try
            {
                await _reviewService.CreateAsync(reviewCreateDto);
                await _reviewService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(reviewCreateDto);
            }
            catch (Exception)
            {
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(reviewCreateDto);
            }
        }


        //UPDATE
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ReviewViewItemDto? review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            ReviewUpdateDto reviewUpdateDto = new ReviewUpdateDto
            {
                Id = id,
                Comment = review.Comment,
                Rating = review.Rating
            };

            return View(reviewUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ReviewUpdateDto reviewUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(reviewUpdateDto);
            }

            bool updated = await _reviewService.UpdateAsync(reviewUpdateDto);
            if (!updated)
            {
                return NotFound();
            }

            await _reviewService.SaveChangesAsync();        
            return RedirectToAction(nameof(Index));
        }


        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewService.DeleteAsync(id);
            await _reviewService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
