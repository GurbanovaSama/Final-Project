using FoodHut.BL.DTOs;

namespace FoodHut.BL.Services.Abstractions;

public interface IReviewService
{
    Task<ICollection<ReviewListItemDto>> GetAllAsync();
    Task<ReviewViewItemDto?> GetByIdAsync(int id);
    Task CreateAsync(ReviewCreateDto reviewCreateDto);
    Task<bool> UpdateAsync(ReviewUpdateDto reviewUpdateDto);
    Task<bool> DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
