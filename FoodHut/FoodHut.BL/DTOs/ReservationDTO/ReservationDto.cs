using System.ComponentModel.DataAnnotations;

namespace FoodHut.BL.DTOs;

public record ReservationDto
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, Phone]
    public string PhoneNumber { get; set; }

    [Required, Range(1, 20)]
    public int NumberOfGuests { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime Date { get; set; }
}
