using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;

namespace FoodHut.BL.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();
        CreateMap<ProductListItemDto, Product>().ReverseMap();
        CreateMap<ProductViewItemDto, Product>().ReverseMap();
        CreateMap<GetProductDto, Product>().ReverseMap();
    }
}
