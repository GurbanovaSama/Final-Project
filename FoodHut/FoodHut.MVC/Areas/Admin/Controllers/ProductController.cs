using FoodHut.BL.DTOs;
using FoodHut.BL.Exceptions;
using FoodHut.BL.Services.Abstractions;
using FoodHut.BL.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHut.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<ProductListItemDto> list = await _productService.GetListItemsAsync();

                return View(list);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }
        //DETAILS
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await _productService.GetByIdAsync(id));
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

        //CREATE
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Name");
                return View();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {

            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Name");
                return View(productCreateDto);
            }

            try
            {
                await _productService.CreateAsync(productCreateDto);
                await _productService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Name");
                ModelState.AddModelError("CustomError", ex.Message);
                return View(productCreateDto);
            }
            catch (Exception)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Name");
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(productCreateDto);
            }
        }


        //UPDATE
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Name");
                return View(await _productService.GetByIdForUpdateAsync(id));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Name");
                return View(productUpdateDto);
            }

            try
            {
                await _productService.UpdateAsync(productUpdateDto);
                await _productService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Name");
                ModelState.AddModelError("CustomError", ex.Message);
                return View(productUpdateDto);
            }
            catch (Exception)
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Name");
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(productUpdateDto);
            }
        }

        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                await _productService.SaveChangesAsync();
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
    }
}
