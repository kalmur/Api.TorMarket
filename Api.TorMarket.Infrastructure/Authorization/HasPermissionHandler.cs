using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Api.TorMarket.Infrastructure.Authorization;

public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        HasPermissionRequirement requirement
    )
    {
        // Temporary debugging - remove after fixing
        var allClaims = context.User.Claims.ToList();

        var matchingClaims = context.User.FindAll("permissions");

        var permissions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var claim in matchingClaims)
        {
            var value = claim.Value?.Trim();
            if (!string.IsNullOrEmpty(value) && value.StartsWith("["))
            {
                try
                {
                    var arr = JsonSerializer.Deserialize<string[]>(value);
                    if (arr != null)
                    {
                        foreach (var p in arr)
                            permissions.Add(p);
                    }
                }
                catch
                {
                    // ignore malformed JSON; fall through
                }
            }
            else if (!string.IsNullOrEmpty(value))
            {
                permissions.Add(value);
            }
        }

        if (permissions.Contains(requirement.Permission))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}