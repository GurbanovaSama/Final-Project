using FoodHut.BL.DTOs;


namespace FoodHut.BL.Services.Abstractions
{
    public interface ISettingService
    {
        Task<SettingsDTO> GetSettingsAsync();
        void UpdateSettings(SettingsDTO dto);
        Task<int> SaveChangesAsync();
    }
}
