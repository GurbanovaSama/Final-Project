using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;

namespace FoodHut.BL.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryCreateDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        CreateMap<CategoryListItemDto, Category>().ReverseMap();
        CreateMap<CategoryViewItemDto, Category>().ReverseMap();
    }
}
