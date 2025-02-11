using FluentValidation;

namespace FoodHut.BL.DTOs;

public record ReviewCreateDto
{
    public string? UserId { get; set; }
    public string? UserName { get; set; } 
    public string? Comment { get; set; }
    public string? UserRole { get; set; }
    public double Rating { get; set; }
    public int RestaurantId { get; set; }
}

public class ReviewCreateDtoValidator : AbstractValidator<ReviewCreateDto>
{
    public ReviewCreateDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID cannot be empty!");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UsserName cannot be empty!")
            .MaximumLength(100).WithMessage("Username must not be longer than 100 characters.");

        RuleFor(x => x.UserRole)
           .NotEmpty().WithMessage("UserRole cannot be empty!")
           .MaximumLength(100).WithMessage("UserRole must not be longer than 100 characters.");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment cannot be empty!")
            .MaximumLength(500).WithMessage("The comment can be a maximum of 500 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.RestaurantId)
            .GreaterThan(0).WithMessage("Restaurant ID must be greater than 0.");

    }
}