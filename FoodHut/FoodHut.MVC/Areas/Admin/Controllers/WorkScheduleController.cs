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
            ICollection<WorkScheduleListItemDto> schedules = await _service.GetAllAsync();
            return View(schedules);
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
            ViewBag.WorkSchedules = (await _service.GetAllAsync()).Select(x => 
            new SelectListItem
            {
                Value = x.Id.ToString(),    
                Text = $"{x.Day} ({x.OpenTime} - {x.CloseTime})"
            }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkScheduleCreateDto dto)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Restaurants = await _restaurantService.GetAllAsync();
                return View(dto);   
            }
            if (dto.RestaurantId == 0) // və ya null-dursa
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
            if(schedule == null)
            {
                return NotFound();
            }

            ViewBag.Restaurants = await _restaurantService.GetAllAsync();   

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
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            bool updated = await _service.UpdateAsync(dto); 
            if(!updated)
            {
                return NotFound();
            }
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            WorkScheduleViewItemDto? schedule = await _service.GetByIdAsync(id);
            if(schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deleted = await _service.DeleteAsync(id);
            if(!deleted)
            {
                return NotFound();
            }
            await _service.SaveChangesAsync();  
            return RedirectToAction(nameof(Index));     
        }


    }
}
