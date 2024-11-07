using Ginosis.Common.Application;

namespace SchoolHive.Modules.Users.Domain.Users;

public class UserErrors
{
    public static Error NotFound(Guid customerId) =>
             Error.NotFound("User.NotFound", $"The user cannot found");

    public static readonly Error AlreadyUpdated = Error.Problem(
        "User.AlreadyUpdated",
        "The user data is already updated");
}

