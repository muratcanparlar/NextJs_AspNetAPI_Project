using Ginosis.Common.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolHive.Modules.Users.Domain.Users;
using SchoolHive.Modules.Users.Infrastructure.Databaase;
using SchoolHive.Modules.Users.Infrastructure.Users;


namespace SchoolHive.Modules.Users.Infrastructure
{
    public static class UserModule
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);

            return services;
        }
        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UsersDbContext>((sp, options) =>
            options.UseNpgsql(
                configuration.GetConnectionString("Database")
            ).UseSnakeCaseNamingConvention());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
        }
    }
}
