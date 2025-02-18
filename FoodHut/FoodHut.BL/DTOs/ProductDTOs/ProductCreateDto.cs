using FluentValidation;
using FoodHut.BL.Utilities;
using Microsoft.AspNetCore.Http;

namespace FoodHut.BL.DTOs;

public record ProductCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public IFormFile Image { get; set; }
    public int RestaurantId { get; set; }
    public int CategoryId { get; set; }
}


public class ProductCreateDtoValidation : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidation()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .MinimumLength(2).WithMessage("Name must be at least 2 symbols long!")
            .MaximumLength(100).WithMessage("The length of the name cannot exceed 100 symbols!");

        RuleFor(e => e.Description)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .MinimumLength(2).WithMessage("Description must be at least 2 symbols long!")
            .MaximumLength(1000).WithMessage("The length of the description cannot exceed 1000 symbols!");

        RuleFor(e => e.Price)
            .NotEmpty().WithMessage("Price cannot be empty!")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be 0 or greater!")
            .LessThanOrEqualTo(99999999.99m).WithMessage("Price must be 99999999.99 or less than that!");

        RuleFor(e => e.Image)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!")
            .Must(e => e.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
            .Must(e => e.CheckType("image")).WithMessage("File must be image!");

        RuleFor(e => e.RestaurantId)
            .NotEmpty().WithMessage("Restaurant id cannot be empty!")
            .GreaterThan(0).WithMessage("Restaurant id must be a natural number!");

        RuleFor(e => e.CategoryId)
            .NotEmpty().WithMessage("Category id cannot be empty!")
            .GreaterThan(0).WithMessage("Category id must be a natural number!");
    }
}