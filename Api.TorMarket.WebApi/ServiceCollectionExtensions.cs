using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace Api.TorMarket.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebApiDependencies(
        this IServiceCollection services
    ) =>
        services
            .AddSwagger()
            .AddApiVersioning()
            .AddCors();

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
        this IServiceCollection services
    ) =>
        services
            .AddCors(options =>
            {
                options.AddDefaultPolicy(corsBuilder =>
                {
                    corsBuilder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
}
