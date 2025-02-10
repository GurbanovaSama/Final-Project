using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.DAL.Models;

namespace FoodHut.BL.Profiles;

public class WorkScheduleProfile : Profile
{
    public WorkScheduleProfile()
    {
        CreateMap<WorkScheduleCreateDto, WorkSchedule>().ReverseMap();
        CreateMap<WorkScheduleUpdateDto, WorkSchedule>().ReverseMap();
        CreateMap<WorkScheduleListItemDto, WorkSchedule>().ReverseMap();
        CreateMap<WorkScheduleViewItemDto, WorkSchedule>().ReverseMap();
    }
}
