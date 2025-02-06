using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;

namespace FoodHut.BL.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<RestaurantCreateDto, Restaurant>().ReverseMap();
        CreateMap<RestaurantUpdateDto, Restaurant>().ReverseMap();
        CreateMap<RestaurantListItemDto, Restaurant>().ReverseMap();
        CreateMap<RestaurantViewItemDto, Restaurant>().ReverseMap();
    }
}
