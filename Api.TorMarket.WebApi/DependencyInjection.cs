using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api.TorMarket.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiDependencies(
        this IServiceCollection services
    ) =>
        services
            .AddCors()
            .AddAuthentication();

    private static IServiceCollection AddCors(
        this IServiceCollection services
    ) =>
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(corsBuilder =>
            {
                corsBuilder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

    private static IServiceCollection AddAuthentication(
        this IServiceCollection services
    )
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme,
                options =>
                {
                    options.Authority = "https://tormarket.us.auth0.com/";
                    options.Audience = "https://tormarket.com/api";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
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
}
