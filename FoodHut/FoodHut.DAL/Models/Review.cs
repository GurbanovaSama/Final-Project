using FoodHut.DAL.Models.Base;

namespace FoodHut.DAL.Models;

public class Review : BaseEntity
{
    public string UserId { get; set; }      
    public string UserName { get; set; }
    public string UserRole { get; set; }
    public string Comment { get; set; }
    public double Rating { get; set; }     
    public int RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; } 
}
