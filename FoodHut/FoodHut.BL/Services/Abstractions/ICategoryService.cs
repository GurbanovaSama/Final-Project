using FoodHut.BL.DTOs;

namespace FoodHut.BL.Services.Abstractions;

public interface ICategoryService
{
    Task<ICollection<CategoryListItemDto>> GetAllAsync();
    Task<CategoryViewItemDto?> GetByIdAsync(int id);
    Task CreateAsync(CategoryCreateDto categoryCreateDto);
    Task<bool> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
    Task<bool> DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
