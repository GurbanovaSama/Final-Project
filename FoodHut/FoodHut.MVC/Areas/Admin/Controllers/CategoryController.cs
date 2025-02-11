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
            //if(categories == null )
            //{
            //    categories = new List<CategoryListItemDto>();
            //}
            return View(categories);
        }

        //DETAILS
        public async Task<IActionResult> Details(int id)
        {
            if(id<= 0)
            {
                //TempData["ErrorMessage"] = "Invalid category ID.";
                //return RedirectToAction(nameof(Index));
                return NotFound();  
            }
            CategoryViewItemDto category = await _categoryService.GetByIdAsync(id);    
            if(category == null)
            {
                //TempData["ErrorMessage"] = "The requested category was not found.";
                //return RedirectToAction(nameof(Index));     
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
            //if(categoryCreateDto == null)
            //{
            //    return BadRequest("Category information cannot be empty.");
            //}
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
            if(id <= 0)
            {
                return NotFound();  
            }
            CategoryViewItemDto category = await _categoryService.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound();
            }

            var categoryUpdateDto = new CategoryUpdateDto
            {
                Id = id,
                Name = category.Name,
                RestaurantId = category.RestaurantId
            };

            return View(categoryUpdateDto);

            //return View(new CategoryUpdateDto { Id = id, Name = category?.Name ?? ""});     
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateAsync(dto);
                if (result)
                {
                    await _categoryService.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Category not found.");
            }
            return View(dto);
            //if(!ModelState.IsValid)
            //{
            //    return View(dto);   
            //}

            //bool isUpdated = await _categoryService.UpdateAsync(dto);   
            //if(!isUpdated)
            //{
            //    return NotFound();
            //}
            //return RedirectToAction(nameof(Index));
        }


        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result)
            {
                await _categoryService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    bool isDeleted = await _categoryService.DeleteAsync(id);      
        //    if(!isDeleted)
        //    {
        //        return NotFound();  
        //    }

        //    await _categoryService.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
