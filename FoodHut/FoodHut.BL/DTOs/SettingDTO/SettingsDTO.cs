using System.ComponentModel.DataAnnotations;

namespace FoodHut.BL.DTOs;

public record SettingsDTO
{
    [Display(Prompt = "Address")]
    [Required(ErrorMessage = "Address is required.")]
    public string Address { get; set; }

    [Display(Prompt = "Phone number")]
    [DataType(DataType.PhoneNumber)]
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string? Phone { get; set; }

    [Display(Prompt = "Email")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }

    [Display(Prompt = "Google Map API Key")]
    public string? GoogleMapApiKey { get; set; }

}
