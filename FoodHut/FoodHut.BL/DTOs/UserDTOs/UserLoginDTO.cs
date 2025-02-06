using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace FoodHut.BL.DTOs;

public record UserLoginDTO
{
    [Display(Prompt = "Username")]
    public string UserName { get; set; }

    [Display(Prompt = "Password")]
    [DataType(DataType.Password)]   
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }        
}


public class UserLoginDTOValidation : AbstractValidator<UserLoginDTO>
{
    public UserLoginDTOValidation()
    {
        RuleFor(e => e.UserName)
            .NotEmpty().WithMessage("Username cannot be empty!")
            .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password cannot be empty!")
            .MinimumLength(4).WithMessage("Password must be at least 4 symbols long!");
    }
}
