using System.ComponentModel.DataAnnotations;

namespace FoodHut.BL.DTOs;

public record WorkScheduleUpdateDto
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "The day should definitely be celebrated.")]
    [EnumDataType(typeof(DayOfWeek), ErrorMessage = "Incorrect day type selected.")]
    public DayOfWeek Day { get; set; }

    [Required(ErrorMessage = "The opening hours must be noted.")]
    [DataType(DataType.Time)]
    public TimeSpan OpenTime { get; set; }

    [Required(ErrorMessage = "The closing time must be noted.")]
    [DataType(DataType.Time)]
    [TimeRange] // Custom validator
    public TimeSpan CloseTime { get; set; }
}
