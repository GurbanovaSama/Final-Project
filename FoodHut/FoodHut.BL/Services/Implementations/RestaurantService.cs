using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;
using FoodHut.DAL.Repository.Implementations;

namespace FoodHut.BL.Services.Implementations;

public class RestaurantService : IRestaurantService
{
    private readonly IRepository<Restaurant> _repository;
    private readonly IMapper _mapper;

    public RestaurantService(IMapper mapper, IRepository<Restaurant> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }


    public async Task<ICollection<RestaurantListItemDto>> GetAllAsync()
    {
        ICollection<Restaurant> restaurants = await _repository.GetAllAsync();
        return _mapper.Map<ICollection<RestaurantListItemDto>>(restaurants);
    }

    public async Task<RestaurantViewItemDto?> GetByIdAsync(int id)
    {
        Restaurant? restaurant = await _repository.GetByIdAsync(id);
        return _mapper.Map<RestaurantViewItemDto>(restaurant);
    }

    public async Task<RestaurantUpdateDto?> GetUpdateByIdAsync(int id)
    {
        Restaurant? restaurant = await _repository.GetByIdAsync(id);
        return restaurant == null ? null : _mapper.Map<RestaurantUpdateDto>(restaurant);
    }

    public async Task CreateAsync(RestaurantCreateDto createDto)
    {
        Restaurant restaurant = _mapper.Map<Restaurant>(createDto);
        await _repository.CreateAsync(restaurant);
    }

    public async Task UpdateAsync(RestaurantUpdateDto updateDto)
    {
        Restaurant? restaurant = await _repository.GetByIdAsync(updateDto.Id);
        if (restaurant != null)
        {
            _mapper.Map(updateDto, restaurant);
            _repository.Update(restaurant);
        }
    }

    public async Task DeleteAsync(int id)
    {
        Restaurant? restaurant = await _repository.GetByIdAsync(id);
        if (restaurant != null)
        {
            _repository.Delete(restaurant);
        }
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
