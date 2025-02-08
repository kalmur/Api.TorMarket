using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Domain.Entities;
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
    )
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(
                configuration.GetConnectionString("Default")));

        services
            .AddScoped<IApplicationDbContext, ApplicationDbContext>()
            .AddScoped<IAddressRepository, AddressRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IOrderLineRepository, OrderLineRepository>()
            .AddScoped<IOrderStatusRepository, OrderStatus>()
            .AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
            .AddScoped<ISiteUserRepository, SiteUserRepository>()
            .AddScoped<IUserAddressRepository, UserAddressRepository>()
            .AddScoped<IUserProductReviewRepository, UserProductReviewRepository>();

        return services;
    }
}
