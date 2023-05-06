using BMarketo.Models.Contexts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BMarketo.Services.Authorization
{
    public class RoleHandler : IAuthorizationHandler
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RoleHandler> _logger;

        public RoleHandler(UserManager<AppUser> userManager, ILogger<RoleHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();
            var user = await _userManager.GetUserAsync(context.User);
            if (user == null)
            {
                _logger.LogInformation("User not found.");
                return;
            }

            _logger.LogInformation($"User: {user.Email}, Id: {user.Id}");

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                _logger.LogInformation($"User role: {role}");
            }

            foreach (var requirement in pendingRequirements)
            {
                if (requirement is RolesAuthorizationRequirement rolesRequirement)
                {
                    foreach (var requiredRole in rolesRequirement.AllowedRoles)
                    {
                        _logger.LogInformation($"Roles required: {requiredRole}");
                        if (await _userManager.IsInRoleAsync(user, requiredRole))
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
            }
        }
    }
}
