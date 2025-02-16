using FluentValidation;
using FoodHut.BL.Utilities;
using Microsoft.AspNetCore.Http;

namespace FoodHut.BL.DTOs;

public record RestaurantCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }        
    public IFormFile? Image { get; set; }
}

public class RestaurantCreateDtoValidation : AbstractValidator<RestaurantCreateDto>
{
    public RestaurantCreateDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .MinimumLength(2).WithMessage("Name must be at least 2 symbols long!")
            .MaximumLength(100).WithMessage("The length of the name cannot exceed 100 symbols!");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .MinimumLength(10).WithMessage("Description must be at least 10 symbols long!")
            .MaximumLength(500).WithMessage("The length of the description cannot exceed 500 symbols!");

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
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!")
            .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
            .Must(x => x.CheckType("image")).WithMessage("File must be image!");

        RuleFor(x => x.ImageUrl)
            .Must(x => string.IsNullOrEmpty(x) || Uri.IsWellFormedUriString(x, UriKind.Absolute)).WithMessage("Image URL must be valid if provided.");
    }
}