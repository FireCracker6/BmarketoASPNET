namespace BMarketo.ViewModels;

public class UserProfileViewModel
{
    public string? UserId { get; set; } 
    public string DisplayName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; } 
    public string? ProfileImageUrl { get; set; } 
    public IFormFile? ProfileImage { get; set; } 
}
