using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.BL.Services.Implementations;
using FoodHut.BL.Utilities;
using FoodHut.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHut.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _service;


        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            ICollection<RestaurantListItemDto> restaurants = await _service.GetAllAsync();
            return View(restaurants);
        }

        //DETAILS
        public async Task<IActionResult> Details(int id)
        {
            RestaurantViewItemDto? restaurant = await _service.GetByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound("Restaurant not found.");
            }
            return View(restaurant);
        }

        //CREATE
        public async Task<IActionResult> Create()
        {
            var restaurants = await _service.GetAllAsync();

            var restaurantSelectList = restaurants
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Name
                })
                .ToList();

            ViewBag.Restaurants = restaurantSelectList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RestaurantCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Restaurants = (await _service.GetAllAsync()).Select(r =>
                new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Name
                }).ToList();

                return View(dto);
            }

            if (dto.Image != null)
            {
                if (dto.Image != null)
                {
                    if (!dto.Image.CheckType("image"))
                    {
                        ModelState.AddModelError("Image", "You can only upload images.");
                        return View(dto);
                    }
                    dto.ImageUrl = await dto.Image.SaveAsync("restaurant");
                }
                else
                {
                    ModelState.AddModelError("Image", "Please upload an image.");
                    return View(dto);
                }
            }

            try
            {
                await _service.CreateAsync(dto);
                await _service.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the restaurant.");
                return View(dto);
            }
           
            return RedirectToAction(nameof(Index));
        }

        //UPDATE
        public async Task<IActionResult> Update(int id)
        {
           RestaurantUpdateDto? restaurant = await _service.GetUpdateByIdAsync(id);  
            if (restaurant == null)
            {
                return NotFound("Restaurant not found.");
            }

            ViewBag.Restaurants = (await _service.GetAllAsync()).Select(r =>
              new SelectListItem
              {
                 Value = r.Id.ToString(),
                 Text = r.Name
              }).ToList();

            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RestaurantUpdateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var existingRestaurant = await _service.GetByIdAsync(dto.Id);

            if (existingRestaurant == null) return NotFound();

            if (dto.Image != null)
            {
                if (!dto.Image.CheckType("image"))
                {
                    ModelState.AddModelError("Image", "You can only upload images.");
                    return View(dto);
                }
                dto.ImageUrl = await dto.Image.SaveAsync("restaurants");
            }
            else
            {
                ModelState.AddModelError("Image", "Please upload an image.");
                return View(dto);
            }

            await _service.UpdateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
