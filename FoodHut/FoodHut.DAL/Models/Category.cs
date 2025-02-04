using FoodHut.DAL.Models.Base;

namespace FoodHut.DAL.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }     
    public ICollection<Product>? Products { get; set; }      
}
