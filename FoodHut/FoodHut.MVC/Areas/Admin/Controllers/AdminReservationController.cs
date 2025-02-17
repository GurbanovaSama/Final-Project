using FoodHut.BL.DTOs;
using FoodHut.BL.Exceptions;
using FoodHut.BL.Services.Abstractions;
using FoodHut.BL.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminReservationController : Controller
    {
        private readonly IReservationService _service;

        public AdminReservationController(IReservationService service)
        {
            _service = service;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            ICollection<ReservationDto> reservations = await _service.GetAllReservationsAsync();
            return View(reservations);
        }


        //UPDATE
        public async Task<IActionResult> Update(int id)
        {
            ReservationDto? reservation = await _service.GetReservationByIdAsync(id);
            if (reservation == null) return NotFound();
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ReservationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _service.UpdateReservationAsync(dto);
                await _service.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }




        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteReservationAsync(id);
                await _service.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            ReservationDto? reservation = await _service.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

    }
}
