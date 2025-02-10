using FoodHut.BL.DTOs;

namespace FoodHut.BL.Services.Abstractions;

public interface IRestaurantService
{
    Task<ICollection<RestaurantListItemDto>> GetAllAsync();
    Task<RestaurantViewItemDto?> GetByIdAsync(int id);       
    Task<RestaurantUpdateDto?> GetUpdateByIdAsync(int id);      
    Task CreateAsync(RestaurantCreateDto createDto);
    Task UpdateAsync(RestaurantUpdateDto updateDto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
