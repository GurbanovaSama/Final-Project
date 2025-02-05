using FoodHut.DAL.Models.Base;

namespace FoodHut.DAL.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }    
    public int RestaurantId { get; set; }           
    public Restaurant? Restaurant { get; set; }      
    public ICollection<Product>? Products { get; set; }      
}
