using FoodHut.BL.DTOs;

namespace FoodHut.BL.Services.Abstractions;

public interface IProductService
{
    Task<ICollection<ProductListItemDto>> GetAllAsync();
    Task<ProductViewItemDto?> GetByIdAsync(int id);
    Task CreateAsync(ProductCreateDto productCreateDto);
    Task<bool> UpdateAsync(ProductUpdateDto productUpdateDto);
    Task<bool> DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
