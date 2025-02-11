using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.BL.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHut.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkScheduleController : Controller
    {
        private readonly IWorkScheduleService _service;
        private readonly IRestaurantService _restaurantService;

        public WorkScheduleController(IWorkScheduleService service, IRestaurantService restaurantService)
        {
            _service = service;
            _restaurantService = restaurantService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
            ICollection<WorkScheduleListItemDto> schedules = await _service.GetAllAsync();
            return View(schedules);
            }
            catch(Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        //DETAILS
        public async Task<IActionResult> Details(int  id)
        {
            WorkScheduleViewItemDto? schedule = await _service.GetByIdAsync(id);
            if(schedule == null)
            {
                return NotFound();  
            }
            return View(schedule);
        }

        //CREATE
        public async Task<IActionResult> Create()
        {
            ViewBag.Restaurants = (await _restaurantService.GetAllAsync()).Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkScheduleCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Restaurants = (await _restaurantService.GetAllAsync()).Select(x =>
                    new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    }).ToList();

                return View(dto);
            }

            if (dto.RestaurantId == 0)
            {
                ModelState.AddModelError("", "Restaurant is required.");
                return View(dto);
            }

            await _service.CreateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //UPDATE
        public async Task<IActionResult> Update(int id)
        {
            WorkScheduleViewItemDto? schedule = await _service.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            ViewBag.Restaurants = (await _restaurantService.GetAllAsync()).Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

            WorkScheduleUpdateDto dto = new()
            {
                Id = id,
                Day = Enum.Parse<DayOfWeek>(schedule.Day),
                OpenTime = TimeSpan.Parse(schedule.OpenTime),
                CloseTime = TimeSpan.Parse(schedule.CloseTime)
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(WorkScheduleUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Restaurants = (await _restaurantService.GetAllAsync()).Select(x =>
                    new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    }).ToList();

                return View(dto);
            }

            bool updated = await _service.UpdateAsync(dto);
            if (!updated)
            {
                return NotFound();
            }

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
