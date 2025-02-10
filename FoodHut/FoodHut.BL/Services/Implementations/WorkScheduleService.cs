using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;

namespace FoodHut.BL.Services.Implementations;

public class WorkScheduleService : IWorkScheduleService
{
    private readonly IRepository<WorkSchedule> _repository;
    private readonly IMapper _mapper;

    public WorkScheduleService(IMapper mapper, IRepository<WorkSchedule> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }


    public async Task<ICollection<WorkScheduleListItemDto>> GetAllAsync()
    {
        ICollection<WorkSchedule> scheduleList = await _repository.GetAllAsync();
        return _mapper.Map<ICollection<WorkScheduleListItemDto>>(scheduleList);         
    }

    public async Task<WorkScheduleViewItemDto?> GetByIdAsync(int id)
    {
        WorkSchedule? schedule = await _repository.GetByIdAsync(id);
        return schedule is null ? null : _mapper.Map<WorkScheduleViewItemDto>(schedule);
    }

    public async Task CreateAsync(WorkScheduleCreateDto workScheduleCreateDto)
    {
        WorkSchedule schedule = _mapper.Map<WorkSchedule>(workScheduleCreateDto);
        await _repository.CreateAsync(schedule);   
    }

    public async Task<bool> UpdateAsync(WorkScheduleUpdateDto workScheduleUpdateDto)
    {
        WorkSchedule? existingSchedule = await _repository.GetByIdAsync(workScheduleUpdateDto.Id);
        if (existingSchedule is null) return false; 

        _mapper.Map(workScheduleUpdateDto, existingSchedule);
        _repository.Update(existingSchedule);
        return true;
    }


    public async Task<bool> DeleteAsync(int id)
    {
        WorkSchedule? schedule = await _repository.GetByIdAsync(id);
        if (schedule is null) return false; 

        _repository.Delete(schedule);   
        return true;
    }


    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();      
}
