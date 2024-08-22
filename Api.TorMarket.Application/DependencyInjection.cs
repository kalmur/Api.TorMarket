using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Services;

namespace Api.TorMarket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var currentAssembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(config => 
            config.RegisterServicesFromAssembly(currentAssembly)
        );

        services
            .AddSingleton<IPasswordService, PasswordService>()
            .AddSingleton<IPasswordGenerator, PasswordGenerator>()
            .AddSingleton<IPasswordValidator, PasswordValidator>();

        return services;
    }
}
