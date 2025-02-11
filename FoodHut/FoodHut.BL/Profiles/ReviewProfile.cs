using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;

namespace FoodHut.BL.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<ReviewCreateDto, Review>().ReverseMap();
        CreateMap<ReviewUpdateDto, Review>().ReverseMap();
        CreateMap<ReviewListItemDto, Review>().ReverseMap();
        CreateMap<ReviewViewItemDto, Review>().ReverseMap();
    }
}
