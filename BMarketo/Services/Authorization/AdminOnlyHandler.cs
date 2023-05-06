using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BMarketo.Services.Authorization;

public class AdminOnlyHandler : IAuthorizationHandler
{
    private readonly ILogger<AdminOnlyHandler> _logger;

    public AdminOnlyHandler(ILogger<AdminOnlyHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        foreach (var requirement in context.PendingRequirements.ToArray())
        {
            if (requirement is AssertionRequirement)
            {
                var user = context.User;
                if (user == null)
                {
                    _logger.LogInformation("User is not authenticated.");
                    context.Fail();
                    continue;
                }

                var rolesClaim = user.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
                _logger.LogInformation($"User: {user.Identity.Name}, Roles: {string.Join(", ", rolesClaim)}");

                if (rolesClaim.Contains("Admin"))
                {
                    _logger.LogInformation("User is an Admin.");
                    context.Succeed(requirement);
                }
                else
                {
                    _logger.LogInformation("User is not an Admin.");
                    context.Fail();
                }
            }
        }

        return Task.CompletedTask;
    }
}
