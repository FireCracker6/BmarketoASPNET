using System.Security.Claims;
using BMarketo.Models.Contexts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BMarketo.Models.Entities.Identity;


public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public CustomClaimsPrincipalFactory(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(user);

        claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));

        // Check if there is only one user in the database.
        if (await _userManager.Users.CountAsync() == 1)
        {
            // Ensure the "Admin" role exists and add the role claim.
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
        }
        else
        {
            // Ensure the "User" role exists and add the role claim.
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
            await _userManager.AddToRoleAsync(user, "User");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "User"));
        }

        return claimsIdentity;
    }
}