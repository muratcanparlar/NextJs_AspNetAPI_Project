using Ginosis.Common.Application.Exceptions;
using System.Security.Claims;

namespace Ginosis.Common.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirst(CustomClaims.Sub)?.Value;

        return Guid.TryParse(userId, out Guid parsedUserId) ?
            parsedUserId :
            throw new GinosisException("User identifier is unavailable");
    }
    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
            throw new GinosisException("User identity is unavailable");
    }

    public static HashSet<string> GetPermisions(this ClaimsPrincipal? principal)
    {
        IEnumerable<Claim> permissionClaims = principal?.FindAll(CustomClaims.Permission) ??
                                            throw new GinosisException("Permissions are unavailable");

        return permissionClaims.Select(c => c.Value).ToHashSet();
    }
}

