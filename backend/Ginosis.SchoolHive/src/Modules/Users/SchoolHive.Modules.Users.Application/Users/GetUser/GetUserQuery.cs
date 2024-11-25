using Ginosis.Common.Application.Messaging;

namespace SchoolHive.Modules.Users.Application.Users.GetUser;

public record GetUserQuery(Guid UserId) : IQuery<UserResponse>;


