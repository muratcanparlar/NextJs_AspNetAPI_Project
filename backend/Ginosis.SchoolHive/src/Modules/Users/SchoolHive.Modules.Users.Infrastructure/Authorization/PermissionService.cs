using Ginosis.Common.Application;
using Ginosis.Common.Application.Authorization;
using MediatR;
using SchoolHive.Modules.Users.Application.Users.GetUserPermissions;

namespace SchoolHive.Modules.Users.Infrastructure.Authorization;

internal class PermissionService(ISender sender) : IPermissionService
{
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
    {
        return await sender.Send(new GetUserPermissionsQuery(identityId));
    }
}

