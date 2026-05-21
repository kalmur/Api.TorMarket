using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Infrastructure.Authorization;
using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Infrastructure.Services.FusionAuth;
using Api.TorMarket.Infrastructure.Services.FusionAuth.Cache;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.TorMarket.Infrastructure.Services.Azure;
using Azure.Search.Documents;
using Azure;
using Api.TorMarket.Application.Abstractions.Azure;
using Microsoft.IdentityModel.Tokens;

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
            .AddFusionAuthServices(configuration);

    private static IServiceCollection LoadOptions(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddOptions<FusionAuthConfig>()
            .Bind(
                FusionAuthConfig.GetFusionAuthConfigSection(configuration)
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
        var fusionAuthOptions = FusionAuthConfig.LoadFromConfiguration(configuration);

        var issuer = fusionAuthOptions.Authority.TrimEnd('/');

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme,
                options =>
                {
                    options.MapInboundClaims = false;
                    options.Authority = issuer;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = issuer,
                        ValidAudience = fusionAuthOptions.Audience,
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };
                }
            );

        services.AddAuthorization(options =>
        {
            options.AddPolicy("admin", policy =>
                policy.Requirements.Add(
                        new HasPermissionRequirement("admin", issuer)
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

        services.AddSingleton(sp =>
        {
            string endpoint = "<Your Azure Search Endpoint>";
            string apiKey = "<Your Azure Search API Key>";
            string indexName = "<Your Index Name>";

            var credential = new AzureKeyCredential(apiKey);
            return new SearchClient(new Uri(endpoint), indexName, credential);
        });

        //services.AddSingleton(sp =>
        //{
        //    var endpoint = azureConfig.TextAnalyticsEndpoint ?? string.Empty;
        //    var apiKey = azureConfig.TextAnalyticsApiKey!;
        //    var credential = new AzureKeyCredential(apiKey);

        //    return new TextAnalyticsClient(new Uri(endpoint), credential);
        //});

        services.AddSingleton<IBlobService, BlobService>();
        services.AddScoped<IIndexingService, IndexingService>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<ITextAnalyticsService, TextAnalyticsService>();

        return services;
    }

    private static IServiceCollection AddFusionAuthServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var fusionAuthOptions = FusionAuthConfig.LoadFromConfiguration(configuration);

        services
            .AddScoped<IIdentityProviderService, FusionAuthService>()
            .AddScoped<IFusionAuthQueryBuilder, FusionAuthQueryBuilder>()
            .AddScoped<FusionAuthTokenHandler>();

        services
            .AddHttpClient(ClientNames.FusionAuth, client =>
            {
                client.BaseAddress = new Uri(fusionAuthOptions!.Authority!);
            })
            .AddHttpMessageHandler<FusionAuthTokenHandler>();

        services
            .AddHttpClient(ClientNames.FusionAuthAuthentication, client =>
            {
                client.BaseAddress = new Uri(fusionAuthOptions!.Authority!);
            });

        services.AddFusionAuthTokenCache();

        return services;
    }

    private static void AddFusionAuthTokenCache(
        this IServiceCollection services
    )
    {
        services.AddFusionCache(Constants.FusionCacheInstance);
        services.AddScoped<IFusionAuthTokenCache, FusionAuthTokenCache>();
    }
}
