using FoodHut.DAL.Models.Base;

namespace FoodHut.DAL.Models;

public class Restaurant : BaseEntity
{
    public string Name { get; set; }    
    public string Location { get; set; }
    public ICollection<Product>? Products { get; set; }
    public ICollection<Category>? Categories { get; set; } 

}


