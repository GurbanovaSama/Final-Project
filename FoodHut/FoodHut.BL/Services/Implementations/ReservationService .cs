using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;

namespace FoodHut.BL.Services.Implementations;

public class ReservationService : IReservationService
{
    private readonly IRepository<Reservation> _repository;
    private readonly IMapper _mapper;

    public ReservationService(IMapper mapper, IRepository<Reservation> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ICollection<ReservationDto>> GetAllReservationsAsync()
    {
        ICollection<Reservation> reservations = await _repository.GetAllAsync();
        return _mapper.Map<ICollection<ReservationDto>>(reservations);
    }
    public async Task<ReservationDto?> GetReservationByIdAsync(int id)
    {
        Reservation? reservation = await _repository.GetByIdAsync(id);
        return _mapper.Map<ReservationDto?>(reservation);
    }

    public async Task CreateReservationAsync(ReservationDto dto)
    {
        Reservation reservation = _mapper.Map<Reservation>(dto);
        await _repository.CreateAsync(reservation);
    }
    public async  Task UpdateReservationAsync(ReservationDto dto)
    {
        Reservation reservation = _mapper.Map<Reservation>(dto);
        _repository.Update(reservation);
    }

    public async Task DeleteReservationAsync(int id)
    {
        Reservation? reservation = await _repository.GetByIdAsync(id);
        if (reservation != null)
        {
            _repository.Delete(reservation);
        }
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
