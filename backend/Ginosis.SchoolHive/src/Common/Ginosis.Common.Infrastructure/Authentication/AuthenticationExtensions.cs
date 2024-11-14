using Microsoft.Extensions.DependencyInjection;

namespace Ginosis.Common.Infrastructure.Authentication;

internal static class AuthenticationExtensions
{
    internal static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication().AddJwtBearer();
        services.AddHttpContextAccessor();
        services.ConfigureOptions<JwtBearerConfigureOptions>();
        return services;
    }
}

