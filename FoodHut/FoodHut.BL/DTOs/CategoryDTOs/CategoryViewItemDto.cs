namespace FoodHut.BL.DTOs;

public record CategoryViewItemDto
{
    public string Name { get; set; }
    public int RestaurantId { get; set; }       
}
