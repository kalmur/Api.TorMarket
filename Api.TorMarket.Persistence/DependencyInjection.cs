using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Context;
using Api.TorMarket.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.TorMarket.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    ) => services
        .ConfigureDatabase(configuration)
        .AddRepositories();

    private static IServiceCollection ConfigureDatabase(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                connectionString,
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName!);
                }
            );
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        return services;
    }

    private static IServiceCollection AddRepositories(
        this IServiceCollection services
    ) => services
        .AddScoped<IListingRepository, ListingRepository>()
        .AddScoped<IProductCategoryRepository, ListingCategoryRepository>()
        .AddScoped<IUserRepository, UserRepository>();
}
