﻿using FluentValidation;

namespace FoodHut.BL.DTOs;

public record CategoryUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RestaurantId { get; set; }
}

public class CategoryUpdateDtoValidation : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidation()
    {
        RuleFor(e => e.Id)
            .GreaterThan(0).WithMessage("Id must be a natural number!");

        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .MinimumLength(5).WithMessage("Name must be at least 5 symbols long!")
            .MaximumLength(50).WithMessage("The length of the name cannot exceed 50 symbols!");


        RuleFor(e => e.RestaurantId)
            .NotEmpty().WithMessage("Restaurant id cannot be empty!")
            .GreaterThan(0).WithMessage("Restaurant id must be a natural number!");
    }
}
