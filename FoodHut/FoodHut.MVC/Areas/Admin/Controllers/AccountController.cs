//using FinalExam.Core.Enums;
//using FoodHut.BL.DTOs;
//using FoodHut.BL.Exceptions;
//using FoodHut.BL.Services.Abstractions;
//using Microsoft.AspNetCore.Mvc;

//namespace FoodHut.MVC.Areas.Admin.Controllers
//{
//    [Area("Admi")]
//    public class AccountController : Controller
//    {
//        readonly IAccountService _service;

//        public AccountController(IAccountService service)
//        {
//            _service = service;
//        }

//        public IActionResult Login()
//        {
//            if (User.Identity is not null && User.Identity.IsAuthenticated)
//                return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/");

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Login(UserLoginDTO dto, string? returnUrl = null)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(dto);
//            }

//            try
//            {
//                await _service.LoginAsync(dto);
//            }
//            catch (BaseException ex)
//            {
//                ModelState.AddModelError("CustomError", ex.Message);
//                return View(dto);
//            }
//            catch (Exception)
//            {
//                ModelState.AddModelError("CustomError", "Something went wrong!");
//                return View(dto);
//            }

//            return Redirect(returnUrl ?? (User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/"));
//        }

//        public IActionResult Register()
//        {
//            if (User.Identity is not null && User.Identity.IsAuthenticated)
//                return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/");

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Register(UserRegisterDTO dto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(dto);
//            }

//            try
//            {
//                await _service.RegisterAsync(dto);
//            }
//            catch (BaseException ex)
//            {
//                ModelState.AddModelError("CustomError", ex.Message);
//                return View(dto);
//            }
//            catch (Exception)
//            {
//                ModelState.AddModelError("CustomError", "Something went wrong!");
//                return View(dto);
//            }

//            return Redirect("/admin/account/login");
//        }

//        public async Task<IActionResult> Logout()
//        {
//            try
//            {
//                await _service.LogoutAsync();
//                return Redirect("/");
//            }
//            catch (Exception)
//            {
//                return BadRequest("Something went wrong!");
//            }
//        }
//    }
//}
