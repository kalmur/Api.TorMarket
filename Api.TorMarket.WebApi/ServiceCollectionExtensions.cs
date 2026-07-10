using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace Api.TorMarket.WebApi;

public static class ServiceCollectionExtensions
{
    private const string CorsAllowedOriginsKey = "Cors:AllowedOrigins";

    public static IServiceCollection AddWebApiDependencies(
        this IServiceCollection services,
        IConfiguration configuration
    ) =>
        services
            .AddSwagger()
            .AddApiVersioning()
            .AddCors(configuration);

    private static IServiceCollection AddSwagger(
        this IServiceCollection services
    ) =>
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Api.TorMarket",
                        Version = "v1"
                    }
                );
            });

    private static IServiceCollection AddApiVersioning(
        this IServiceCollection services
    )
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddMvc();

        return services;
    }

    private static IServiceCollection AddCors(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var allowedOrigins = configuration
            .GetSection(CorsAllowedOriginsKey)
            .Get<string[]>() ?? Array.Empty<string>();

        return services.AddCors(options =>
        {
            options.AddDefaultPolicy(corsBuilder =>
            {
                if (allowedOrigins.Length > 0)
                {
                    // Required for the Angular SPA so the BFF refresh-token cookie can flow.
                    corsBuilder
                        .WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                }
                else
                {
                    corsBuilder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            });
        });
    }
}
