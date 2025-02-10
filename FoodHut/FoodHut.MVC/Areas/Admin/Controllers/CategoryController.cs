using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            ICollection<CategoryListItemDto> categories = await _categoryService.GetAllAsync();    
            if(categories == null )
            {
                categories = new List<CategoryListItemDto>();
            }
            return View(categories);
        }

        //DETAILS
        public async Task<IActionResult> Details(int id)
        {
            CategoryViewItemDto? category = await _categoryService.GetByIdAsync(id);    
            if(category == null)
            {
                return NotFound();  
            }
            return View(category);  
        }

        //CREATE
        public IActionResult Create()
        {
            return View();      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            if(!ModelState.IsValid)
            {
                return View(categoryCreateDto); 
            }

            try
            {
                await _categoryService.CreateAsync(categoryCreateDto);
                await _categoryService.SaveChangesAsync();
            }   
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(categoryCreateDto); 
            }
            return RedirectToAction(nameof(Index));     
        }

        //UPDATE
        public async Task<IActionResult> Update(int  id)
        {
            CategoryViewItemDto? category = await _categoryService.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            CategoryUpdateDto categoryUpdateDto = new CategoryUpdateDto
            { 
                Id = id,
                Name = category.Name,
            };

            return View(categoryUpdateDto);     
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);   
            }

            bool isUpdated = await _categoryService.UpdateAsync(dto);   
            if(!isUpdated)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }


        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            await _categoryService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
