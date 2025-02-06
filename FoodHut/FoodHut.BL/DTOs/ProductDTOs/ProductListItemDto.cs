namespace FoodHut.BL.DTOs;

public record ProductListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int RestaurantId { get; set; }
    public int CategoryId { get; set; }
}
