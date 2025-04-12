using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Infrastructure.Services;
using Api.TorMarket.Infrastructure.Services.Interfaces;
using Auth0Net.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.TorMarket.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
       
        services.Configure<Auth0Settings>(
            configuration.GetSection(Auth0Settings.SectionName)
        );

        var options = configuration
            .GetSection(Auth0Settings.SectionName)
            .Get<Auth0Settings>();

        services.AddAuth0AuthenticationClient(config =>
        {
            config.Domain = options!.Domain!;
            config.ClientId = options.ClientId;
            config.ClientSecret = options.ClientSecret;
        });

        services
            .AddScoped<IAuth0UsersClient, Auth0UsersClient>()
            .AddScoped<IAuth0Service, Auth0Service>()
            .AddAuth0ManagementClient()
            .AddManagementAccessToken();

        return services;
    }
}
