using AutoMapper;
using FinalExam.Core.Enums;
using FoodHut.BL.DTOs;
using FoodHut.BL.Exceptions;
using FoodHut.BL.Services.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace FoodHut.BL.Services.Implementations;

public class AccountService : IAccountService
{
    public readonly UserManager<IdentityUser> _userManager;
    public readonly SignInManager<IdentityUser> _signInManager;
    public readonly IMapper _mapper;

    public AccountService(IMapper mapper, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _mapper = mapper;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task RegisterAsync(UserRegisterDTO dto)
    {
        if (await _userManager.FindByNameAsync(dto.UserName) is not null) throw new BaseException();

        if(await _userManager.FindByEmailAsync(dto.Email) is not null) throw new BaseException();

        IdentityUser user = _mapper.Map<IdentityUser>(dto);

        IdentityResult result = await _userManager.CreateAsync(user, dto.Password); 

        if(!result.Succeeded) throw new BaseException();

        result = await _userManager.AddToRoleAsync(user, Roles.User.ToString());

        if(!result.Succeeded) throw new BaseException();    
    }

    public async Task LoginAsync(UserLoginDTO dto)
    {
        IdentityUser user = await _userManager.FindByNameAsync(dto.UserName) ?? throw new BaseException("Credentials are wrong!");

        SignInResult result = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);

        if(!result.Succeeded) throw new BaseException("Credentials are wrong!");
    }


    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();        
    }

}
