using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Infrastructure.Services;
using Auth0Net.DependencyInjection;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Api.TorMarket.Infrastructure.Tests")]
namespace Api.TorMarket.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfigurationManager configuration
    ) =>
        services
            .LoadOptions(configuration)
            .AddAuth0Services(configuration)
            .AddAzureServices(configuration);
    
    private static IServiceCollection LoadOptions(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services
            .AddOptions<Auth0Config>()
            .Bind(
                Auth0Config.GetAuth0ConfigSection(configuration)
            ).ValidateOnStart();

        services
            .AddOptions<AzureConfig>()
            .Bind(
                AzureConfig.GetAzureConfig(configuration)
            ).ValidateOnStart();

        return services;
    }

    private static IServiceCollection AddAuth0Services(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        var auth0Config = Auth0Config.LoadFromConfiguration(configuration);

        services.AddAuth0AuthenticationClient(config =>
        {
            config.Domain = auth0Config.Domain;
            config.ClientId = auth0Config.ClientId;
            config.ClientSecret = auth0Config.ClientSecret;
        });

        services
            .AddScoped<IAuth0UsersClient, Auth0UsersClient>()
            .AddScoped<IAuth0Service, Auth0Service>()
            .AddAuth0ManagementClient()
            .AddManagementAccessToken();

        return services;
    }

    private static IServiceCollection AddAzureServices(
        this IServiceCollection services, 
        IConfigurationManager configuration
    )
    {
        var azureConfig = AzureConfig.LoadFromConfiguration(configuration);

        services.AddSingleton(
            _ => new BlobServiceClient(
                azureConfig.ConnectionString
            )
        );

        services.AddSingleton<IBlobService, BlobService>();

        return services;
    }
}
