using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Infrastructure.Services;
using Api.TorMarket.Infrastructure.Services.Interfaces;
using Auth0Net.DependencyInjection;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.TorMarket.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        AddAuth0Services(services, configuration);
        AddAzureServices(services, configuration);

        return services;
    }

    private static void AddAuth0Services(
        IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services.Configure<Auth0Settings>(
            configuration.GetSection(Auth0Settings.SectionName)
        );

        var auth0Options = configuration
            .GetSection(Auth0Settings.SectionName)
            .Get<Auth0Settings>();

        services.AddAuth0AuthenticationClient(config =>
        {
            config.Domain = auth0Options!.Domain!;
            config.ClientId = auth0Options.ClientId;
            config.ClientSecret = auth0Options.ClientSecret;
        });

        services
            .AddScoped<IAuth0UsersClient, Auth0UsersClient>()
            .AddScoped<IAuth0Service, Auth0Service>()
            .AddAuth0ManagementClient()
            .AddManagementAccessToken();
    }

    private static void AddAzureServices(
        IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services.Configure<AzureSettings>(
            configuration.GetSection(AzureSettings.SectionName)
        );

        var azureOptions = configuration
            .GetSection(AzureSettings.SectionName)
            .Get<AzureSettings>();

        services.AddSingleton(
            config => new BlobServiceClient(
                azureOptions!.ConnectionString
            )
        );

        services.AddSingleton<IBlobService, BlobService>();
    }
}
