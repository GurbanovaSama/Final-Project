namespace FoodHut.BL.DTOs;

public record CategoryListItemDto
{
    public int Id { get; set; }     
    public string Name { get; set; }
    public int RestaurantId { get; set; }
}
