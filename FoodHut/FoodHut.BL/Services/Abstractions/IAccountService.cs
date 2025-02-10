using FoodHut.BL.DTOs;

namespace FoodHut.BL.Services.Abstractions;

public interface IAccountService
{
    Task RegisterAsync(UserRegisterDTO dto);
    Task LoginAsync(UserLoginDTO dto);
    Task LogoutAsync();
}
