using FoodHut.DAL.Models.Base;

namespace FoodHut.DAL.Models;

public class WorkSchedule : BaseEntity
{
    public int RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }

    public DayOfWeek Day { get; set; }  // Bazar Ertəsi - Bazar
    public TimeSpan OpenTime { get; set; }  // Açılış vaxtı (08:00)
    public TimeSpan CloseTime { get; set; }  // Bağlanış vaxtı (22:00)
}
