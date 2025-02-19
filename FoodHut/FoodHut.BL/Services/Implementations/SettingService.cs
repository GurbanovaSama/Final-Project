using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;


namespace FoodHut.BL.Services.Implementations;

public class SettingService : ISettingService
{
    private readonly IRepository<Setting> _settingRepository;
    private readonly IMapper _mapper;

    public SettingService(IMapper mapper, IRepository<Setting> settingRepository)
    {
        _mapper = mapper;
        _settingRepository = settingRepository;
    }

    public async Task<SettingsDTO> GetSettingsAsync()
    {
        return _mapper.Map<SettingsDTO>(await _settingRepository.GetByIdAsync(1));
    }

    public void UpdateSettings(SettingsDTO dto)
    {
        Setting settings = _mapper.Map<Setting>(dto);
        settings.Id = 1;

        _settingRepository.Update(settings);
    }

    public async Task<int> SaveChangesAsync() => await _settingRepository.SaveChangesAsync();
}
