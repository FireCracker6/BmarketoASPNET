using System.Security.Claims;
using BMarketo.Models.Contexts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BMarketo.Models.Entities.Identity;

public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
{
	private readonly UserManager<AppUser> userManager;

	public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
	{
		this.userManager = userManager;
	}

	protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
	{
		var claimsIdentity =  await base.GenerateClaimsAsync(user);


			claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));

		return claimsIdentity;
	}
}
