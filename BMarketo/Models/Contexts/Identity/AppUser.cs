using BMarketo.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace BMarketo.Models.Contexts.Identity;

public class AppUser : IdentityUser 
{
   
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
   // public string? Mobile { get; set; } 
    public string? CompanyName { get; set; } 
    public string? ImageUrl { get; set; }

   
    public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
}
