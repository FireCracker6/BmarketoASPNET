using System.ComponentModel.DataAnnotations;

namespace BMarketo.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    [Required(ErrorMessage = "Message is required.")]
    public string Message { get; set; } = null!;

    public bool SaveUserInfo { get; set; }
}
