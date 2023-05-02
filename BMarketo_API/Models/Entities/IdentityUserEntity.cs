using BMarketo_API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace BMarketo_API.Models.Entities;

public class IdentityUserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string? FirstName { get; set; }
    [ProtectedPersonalData]
    public string? LastName { get; set; }

    public static implicit operator User(IdentityUserEntity entity)
    {
        return new User
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
        };
    }
   
}