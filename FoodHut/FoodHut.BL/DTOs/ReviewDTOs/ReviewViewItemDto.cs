namespace FoodHut.BL.DTOs;

public record ReviewViewItemDto
{
    public string UserName { get; set; }
    public string Comment { get; set; }
    public double Rating { get; set; }
}
