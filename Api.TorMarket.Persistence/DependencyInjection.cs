using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Persistence.Context;
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
        .ConfigureDatabase(configuration);

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
                options =>
                {
                    options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName!);
                }
            );
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        return services;
    }

    //private static IServiceCollection AddRepositories(this IServiceCollection services) =>
    //    services
    //        .AddScoped<IAddressRepository, AddressRepository>()
    //        .AddScoped<IOrderRepository, OrderRepository>()
    //        .AddScoped<IOrderLineRepository, OrderLineRepository>()
    //        .AddScoped<IOrderStatusRepository, OrderStatusRepository>()
    //        .AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
    //        .AddScoped<ISiteUserRepository, SiteUserRepository>()
    //        .AddScoped<IUserAddressRepository, UserAddressRepository>()
    //        .AddScoped<IUserProductReviewRepository, UserProductReviewRepository>();
}
