using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;

namespace FoodHut.BL.Services.Abstractions;

public interface IProductService
{
    Task<ICollection<ProductViewItemDto>> GetViewItemsAsync();
    Task<ICollection<ProductListItemDto>> GetListItemsAsync();
    Task<Product> GetByIdAsync(int id);
    Task<ProductUpdateDto> GetByIdForUpdateAsync(int id);
    Task CreateAsync(ProductCreateDto dto);
    Task UpdateAsync(ProductUpdateDto dto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
    Task<ICollection<GetProductDto>> GetProductsByCategoryIdAsync(int categoryId);   
}
