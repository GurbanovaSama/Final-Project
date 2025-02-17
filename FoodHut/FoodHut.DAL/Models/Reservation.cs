using FoodHut.DAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FoodHut.DAL.Models;

public class Reservation : BaseEntity
{
    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, Phone]
    public string PhoneNumber { get; set; }

    [Required, Range(1, 20)]
    public int NumberOfGuests { get; set; }

    [Required]
    public TimeSpan Time { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime Date { get; set; }
}
