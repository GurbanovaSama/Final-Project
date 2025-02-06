using FluentValidation;

namespace FoodHut.BL.DTOs;

public record ReviewUpdateDto
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public double Rating { get; set; }
}
public class ReviewUpdateDtoValidator : AbstractValidator<ReviewUpdateDto>
{
    public ReviewUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("The ID must be entered correctly.");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("The comment cannot be empty.")
            .MaximumLength(500).WithMessage("The comment can be a maximum of 500 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("The rating should be between 1 and 5.");
    }
}