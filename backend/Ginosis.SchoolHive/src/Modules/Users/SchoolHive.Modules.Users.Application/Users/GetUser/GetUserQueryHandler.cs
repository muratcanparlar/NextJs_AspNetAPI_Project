using Dapper;
using Ginosis.Common.Application;
using Ginosis.Common.Application.Data;
using Ginosis.Common.Application.Messaging;
using SchoolHive.Modules.Users.Domain.Users;
using System.Data.Common;

namespace SchoolHive.Modules.Users.Application.Users.GetUser;

internal class GetUserQueryHandler(IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetUserQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT
                 id AS {nameof(UserResponse.Id)},
                 email AS {nameof(UserResponse.Email)},
                 first_name AS {nameof(UserResponse.FirstName)},
                 last_name AS {nameof(UserResponse.LastName)}
             FROM users.users
             WHERE id = @UserId
             """;

        UserResponse? user = await connection.QuerySingleOrDefaultAsync<UserResponse>(sql, request);

        if (user is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound(request.UserId));
        }

        return user;
    }
}

