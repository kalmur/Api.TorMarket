using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Infrastructure.Services.Auth0;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.TorMarket.Infrastructure.Services.Auth0.Cache;
using Api.TorMarket.Infrastructure.Services.Blob;
using Api.TorMarket.Application.Abstractions.Blob;
using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Api.TorMarket.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDependencies(
        this IServiceCollection services,
        IConfigurationManager configuration
    ) =>
        services
            .LoadOptions(configuration)
            .AddAzureServices(configuration)
            .AddAuth0Services(configuration)
            .AddAuthorizationServices()
            .AddAuthentication()
            .AddAuthorization();


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

    private static IServiceCollection AddAuthorizationServices(
        this IServiceCollection services
    ) =>
        services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

    private static IServiceCollection AddAuthentication(
       this IServiceCollection services
    )
    {
        services
            .AddAuthentication("Bearer")
            .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme,
                options =>
                {
                    options.Authority = "https://tormarket.us.auth0.com/";
                    options.Audience = "https://tormarket.com/api";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier,
                        RoleClaimType = "permissions",
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                    };
                }
            );

        return services;
    }

    private static IServiceCollection AddAuthorization(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var auth0Options = Auth0Config.LoadFromConfiguration(config);

        services.AddAuthorization(options =>
        {
            options.AddPolicy("read:messages", policy => 
                policy.Requirements.Add(
                    new HasScopeRequirement("read:messages", auth0Options.Domain)
                    )
                );
            }
    );

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
