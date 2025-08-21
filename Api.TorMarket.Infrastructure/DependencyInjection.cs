using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Infrastructure.Services.Auth0;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.TorMarket.Infrastructure.Services.Auth0.Cache;
using Api.TorMarket.Infrastructure.Services.Blob;
using Api.TorMarket.Application.Abstractions.Blob;
using Api.TorMarket.Application.Abstractions.IdentityProvider;

namespace Api.TorMarket.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(
        this IServiceCollection services,
        IConfigurationManager configuration
    ) =>
        services
            .LoadOptions(configuration)
            .AddAzureServices(configuration)
            .AddAuth0Services(configuration);

    private static IServiceCollection LoadOptions(
        this IServiceCollection services,
        IConfiguration configuration
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

    private static IServiceCollection AddAuth0Services(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var options = Auth0Config.LoadFromConfiguration(configuration);

        services
            .AddScoped<IIdentityProviderService, Auth0Service>()
            .AddScoped<IAuth0QueryBuilder, Auth0QueryBuilder>()
            .AddScoped<Auth0TokenHandler>();

        services
            .AddHttpClient(ClientNames.Auth0, client =>
            {
                client.BaseAddress = new Uri(options!.Domain!);
            })
            .AddHttpMessageHandler<Auth0TokenHandler>();

        services.AddAuth0Authentication(config =>
        {
            config.ClientId = options!.ClientId;
            config.ClientSecret = options.ClientSecret;
            config.Audience = options!.Audience;
        });

        return services;
    }

    private static void AddAuth0Authentication(
        this IServiceCollection services,
        Action<Auth0Config> config
    )
    {
        services.AddFusionCache(Constants.FusionCacheInstance);
        services.AddScoped<IAuth0TokenCache, Auth0TokenCache>();
    }
}
