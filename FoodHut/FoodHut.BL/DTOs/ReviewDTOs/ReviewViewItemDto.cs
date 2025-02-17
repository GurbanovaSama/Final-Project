namespace FoodHut.BL.DTOs;

public record ReviewViewItemDto
{
    public string Name { get; set; }
    public string Comment { get; set; }     
    public double Rating { get; set; }
}
