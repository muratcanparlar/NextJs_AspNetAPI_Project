using Microsoft.AspNetCore.Authorization;

namespace Ginosis.Common.Infrastructure.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
    public string Permission { get; }
}

