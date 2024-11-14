using Ginosis.Common.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Ginosis.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAuthenticationInternal();

        return services;
    }
}

