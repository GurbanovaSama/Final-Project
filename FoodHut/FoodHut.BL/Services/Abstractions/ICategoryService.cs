using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;

namespace FoodHut.BL.Services.Abstractions;

public interface ICategoryService
{
    Task<ICollection<CategoryViewItemDto>> GetCategoryViewItemsAsync();
    Task<ICollection<CategoryListItemDto>> GetCategoryListItemsAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> GetByIdWithChildrenAsync(int id);
    Task<CategoryUpdateDto> GetByIdForUpdateAsync(int id);
    Task CreateAsync(CategoryCreateDto dto);
    Task UpdateAsync(CategoryUpdateDto dto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
