using AutoMapper;
using FoodHut.BL.DTOs;
using Microsoft.AspNetCore.Identity;

namespace FoodHut.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserLoginDTO, IdentityUser>().ReverseMap();
        CreateMap<UserRegisterDTO, IdentityUser>().ReverseMap();
    }
}
