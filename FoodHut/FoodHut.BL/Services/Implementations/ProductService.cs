using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;

namespace FoodHut.BL.Services.Implementations;

public class ProductService : IProductService
{
    public Task CreateAsync(ProductCreateDto productCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ProductListItemDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewItemDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        throw new NotImplementedException();
    }
}
