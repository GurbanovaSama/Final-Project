using FluentValidation;

namespace FoodHut.BL.DTOs;

public record UserCreateDto
{
    public string Comment { get; set; }
    public double Rating { get; set; }
}

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment cannot be empty!")
            .MaximumLength(500).WithMessage("The comment can be a maximum of 500 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");


    }
}