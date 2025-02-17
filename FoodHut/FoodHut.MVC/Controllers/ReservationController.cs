using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _service.CreateReservationAsync(dto);
            await _service.SaveChangesAsync();

            // Əgər istifadəçi admindirsə, admin panelinə yönləndir
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
            }

            // Müştəri üçün Success səhifəsinə yönləndir
            return RedirectToAction("Success");
        }



        public IActionResult Success()
        {
            return View(); // Müştəri uğurlu rezervasiya etdikdə bu səhifə açılacaq
        }
    }
}
