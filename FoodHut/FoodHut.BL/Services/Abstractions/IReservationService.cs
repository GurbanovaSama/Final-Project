using FoodHut.BL.DTOs;

namespace FoodHut.BL.Services.Abstractions;

public interface IReservationService
{
    Task<ICollection<ReservationDto>> GetAllReservationsAsync();
    Task<ReservationDto?> GetReservationByIdAsync(int id);
    Task CreateReservationAsync(ReservationDto dto);
    Task UpdateReservationAsync(ReservationDto dto);
    Task DeleteReservationAsync(int id);
    Task<int> SaveChangesAsync();
}
