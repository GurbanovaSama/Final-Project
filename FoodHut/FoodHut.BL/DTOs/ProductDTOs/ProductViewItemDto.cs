using Microsoft.AspNetCore.Http;

namespace FoodHut.BL.DTOs;

public record ProductViewItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public IFormFile Image { get; set; }
}
