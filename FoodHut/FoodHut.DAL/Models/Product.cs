using FoodHut.DAL.Models.Base;

namespace FoodHut.DAL.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }      
    public string ImageUrl { get; set; }        
    public int RestaurantId { get; set; }       
    public Restaurant? Restaurant { get; set; }      
    public int CategoryId { get; set; }     
    public Category? Category { get; set; }     
    public ICollection<Review>? Reviews { get; set; }        
}
