using FluentValidation;

namespace FoodHut.BL.DTOs;

public record ReviewListItemDto
{
    public int Id { get; set; }
    public string? UserName { get; set; } 
    public string? Comment { get; set; }
    public double Rating { get; set; }
}
