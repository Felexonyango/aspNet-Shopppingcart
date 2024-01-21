using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ShopOnline.API.Entites.Enums;

namespace ShopOnline.Models.Models;

public class RegisterModel
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(30)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [PasswordPropertyText()]
    [Required]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [PasswordPropertyText]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

    [Required]
    [MaxLength(200)]
    public string AddressLine { get; set; }

    [Required]
    [Phone()]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required]
    [Range(11111, 99999)]
    public int PostalCode { get; set; }

    [Required]
    public int GovernorateId { get; set; }

}
