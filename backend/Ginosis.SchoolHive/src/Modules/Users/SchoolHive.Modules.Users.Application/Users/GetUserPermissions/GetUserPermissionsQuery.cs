using Ginosis.Common.Application.Authorization;
using Ginosis.Common.Application.Messaging;

namespace SchoolHive.Modules.Users.Application.Users.GetUserPermissions;

public record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;

