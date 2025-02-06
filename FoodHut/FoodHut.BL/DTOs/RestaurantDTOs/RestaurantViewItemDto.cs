using Microsoft.AspNetCore.Http;

namespace FoodHut.BL.DTOs;

public record RestaurantViewItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public IFormFile Image { get; set; }
}
