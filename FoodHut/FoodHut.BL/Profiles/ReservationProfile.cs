using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;

namespace FoodHut.BL.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<ReservationDto, Reservation>().ReverseMap();
    }
}
