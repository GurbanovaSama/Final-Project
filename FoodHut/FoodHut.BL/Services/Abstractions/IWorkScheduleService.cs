using FoodHut.BL.DTOs;

namespace FoodHut.BL.Services.Abstractions;

public interface IWorkScheduleService
{
    Task<ICollection<WorkScheduleListItemDto>> GetAllAsync();
    Task<WorkScheduleViewItemDto?> GetByIdAsync(int id);
    Task CreateAsync(WorkScheduleCreateDto workScheduleCreateDto);
    Task<bool> UpdateAsync(WorkScheduleUpdateDto workScheduleUpdateDto);  
    Task<bool> DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
