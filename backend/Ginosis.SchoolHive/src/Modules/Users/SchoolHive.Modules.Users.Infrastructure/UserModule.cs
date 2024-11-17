using Evently.Modules.Users.Infrastructure.Identity;
using Ginosis.Common.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SchoolHive.Modules.Users.Application.Abstractions.Identity;
using SchoolHive.Modules.Users.Domain.Users;
using SchoolHive.Modules.Users.Infrastructure.Databaase;
using SchoolHive.Modules.Users.Infrastructure.Identity;
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
            services.Configure<KeyCloakOptions>(options => configuration.GetSection("Users:KeyCloak").Bind(options));


            services.AddTransient<KeyCloakAuthDelegatingHandler>();

            services.AddHttpClient<KeyCloakClient>((serviceProvider, httpClient) =>
            {
                KeyCloakOptions keyCloakOptions = serviceProvider
                    .GetRequiredService<IOptions<KeyCloakOptions>>().Value;

                httpClient.BaseAddress = new Uri(keyCloakOptions.AdminUrl);
            })
            .AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

            services.AddTransient<IIdentityProviderService, IdentityProviderService>();

            services.AddDbContext<UsersDbContext>((sp, options) =>
            options.UseNpgsql(
                configuration.GetConnectionString("Database")
            ).UseSnakeCaseNamingConvention());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
        }
    }
}
