using Ginosis.Common.Application.Data;
using Npgsql;
using System.Data.Common;

namespace Ginosis.Common.Infrastructure.Data;

public class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}

