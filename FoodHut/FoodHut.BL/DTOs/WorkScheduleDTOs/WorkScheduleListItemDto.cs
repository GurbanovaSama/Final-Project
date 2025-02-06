namespace FoodHut.BL.DTOs;

public record WorkScheduleListItemDto
{
    public int Id { get; set; }
    public string? Day { get; set; }
    public string? OpenTime { get; set; }
    public string? CloseTime { get; set; }
}
