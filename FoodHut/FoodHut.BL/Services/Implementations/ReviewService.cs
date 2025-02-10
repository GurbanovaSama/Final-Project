using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;

namespace FoodHut.BL.Services.Implementations;

public class ReviewService : IReviewService
{
    public Task CreateAsync(ReviewCreateDto reviewCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ReviewListItemDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ReviewViewItemDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ReviewUpdateDto reviewUpdateDto)
    {
        throw new NotImplementedException();
    }
}
