using FluentValidation;
using FoodHut.BL.Utilities;
using Microsoft.AspNetCore.Http;

namespace FoodHut.BL.DTOs;

public record RestaurantUpdateDto
{
    public int Id { get; set; }     
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string ImageURL { get; set; }
    public IFormFile? Image { get; set; }
}

public class RestaurantUpdateDtoValidation : AbstractValidator<RestaurantUpdateDto>
{
    public RestaurantUpdateDtoValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be a natural number!");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .MinimumLength(10).WithMessage("Name must be at least 10 symbols long!")
            .MaximumLength(100).WithMessage("The length of the name cannot exceed 100 symbols!");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .MinimumLength(10).WithMessage("Description must be at least 10 symbols long!")
            .MaximumLength(255).WithMessage("The length of the description cannot exceed 255 symbols!");

        RuleFor(x => x.Location)
           .NotEmpty().WithMessage("Location cannot be empty!")
           .MaximumLength(120).WithMessage("Location cannot exceed 120 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number cannot be empty!")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty!")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Image)
            .Must(x => x is null || x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
            .Must(x => x is null || x.CheckType("image")).WithMessage("File must be image!");
    }
}