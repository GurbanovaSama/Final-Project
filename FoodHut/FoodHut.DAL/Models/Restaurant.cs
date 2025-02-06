using FoodHut.DAL.Models.Base;

namespace FoodHut.DAL.Models;

public class Restaurant : BaseEntity
{
    public string Name { get; set; }    
    public string Description { get; set; } 
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }   
    public string ImageUrl { get; set; }    
    public ICollection<Product>? Products { get; set; }
    public ICollection<Category>? Categories { get; set; }
    public ICollection<WorkSchedule>? WorkSchedules { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}


