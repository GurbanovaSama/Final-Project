using FoodHut.DAL.Models.Base;

namespace FoodHut.DAL.Models;

public class Setting : BaseEntity
{
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string GoogleMapApiKey { get; set; }
}
