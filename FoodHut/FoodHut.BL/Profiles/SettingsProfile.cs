using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;


namespace FoodHut.BL.Profiles
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<SettingsDTO, Setting>().ReverseMap();
        }
    }
}
