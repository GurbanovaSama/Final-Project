using System.ComponentModel.DataAnnotations;

namespace FoodHut.BL.DTOs;

public record WorkScheduleCreateDto
{
    [Required(ErrorMessage = "Restaurant selection is required.")]
    public int RestaurantId { get; set; }

    [Required(ErrorMessage = "The day should definitely be celebrated.")]
    [EnumDataType(typeof(DayOfWeek), ErrorMessage = "Incorrect day type selected.")]
    public DayOfWeek Day { get; set; }

    [Required(ErrorMessage = "The opening hours must be noted.")]
    [DataType(DataType.Time)]
    public TimeSpan OpenTime { get; set; }

    [Required(ErrorMessage = "The closing time must be noted.")]
    [DataType(DataType.Time)]
    [Compare(nameof(OpenTime), ErrorMessage = "Closing time must be later than opening time.")]
    public TimeSpan CloseTime { get; set; }
}

public class TimeRangeAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var model = (WorkScheduleCreateDto)validationContext.ObjectInstance;
        if (model.CloseTime <= model.OpenTime)
        {
            return new ValidationResult("Closing time must be later than opening time.");
        }
        return ValidationResult.Success;
    }
}