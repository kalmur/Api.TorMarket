using Api.TorMarket.Application.Abstractions.Blob;
using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Infrastructure.Authorization;
using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Infrastructure.Services.Auth0;
using Api.TorMarket.Infrastructure.Services.Auth0.Cache;
using Api.TorMarket.Infrastructure.Services.Blob;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.TorMarket.Infrastructure.Services.Auth0.Cache;
using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Api.TorMarket.Infrastructure.Services.Azure;
using Azure.Search.Documents;
using Azure;
using Api.TorMarket.Application.Abstractions.Azure;

namespace Api.TorMarket.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDependencies(
        this IServiceCollection services,
        IConfigurationManager configuration
    ) =>
        services
            .LoadOptions(configuration)
            .AddAuthenticationAndAuthorization(configuration)
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

    private static IServiceCollection AddAuthenticationAndAuthorization(
       this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var auth0Options = Auth0Config.LoadFromConfiguration(configuration);

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme,
                options =>
                {
                    options.MapInboundClaims = false;
                    options.Authority = $"https://{auth0Options.Domain}/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = $"https://{auth0Options.Domain}/",
                        ValidAudience = auth0Options.Audience,
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };
                }
            );

        services.AddAuthorization(options =>
        {
            options.AddPolicy("admin", policy =>
                policy.Requirements.Add(
                        new HasPermissionRequirement("admin", $"https://{auth0Options.Domain}/")
                    )
                );
            }
        );

        services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();

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

        services.AddSingleton<SearchClient>(sp =>
        {
            string endpoint = "<Your Azure Search Endpoint>";
            string apiKey = "<Your Azure Search API Key>";
            string indexName = "<Your Index Name>";

            var credential = new AzureKeyCredential(apiKey);
            return new SearchClient(new Uri(endpoint), indexName, credential);
        });

        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<IIndexingService, IndexingService>();
        services.AddSingleton<IBlobService, BlobService>();

        return services;
    }

    private static IServiceCollection AddAuth0Services(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var auth0Options = Auth0Config.LoadFromConfiguration(configuration);

        services
            .AddScoped<IIdentityProviderService, Auth0Service>()
            .AddScoped<IAuth0QueryBuilder, Auth0QueryBuilder>()
            .AddScoped<Auth0TokenHandler>();

        services
            .AddHttpClient(ClientNames.Auth0, client =>
            {
                client.BaseAddress = new Uri(auth0Options!.Domain!);
            })
            .AddHttpMessageHandler<Auth0TokenHandler>();

        services.AddAuth0Authentication(config =>
        {
            config.ClientId = auth0Options!.ClientId;
            config.ClientSecret = auth0Options.ClientSecret;
            config.Audience = auth0Options!.Audience;
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
