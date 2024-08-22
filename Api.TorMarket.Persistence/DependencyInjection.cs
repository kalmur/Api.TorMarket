using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Repositories;
using Api.TorMarket.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.TorMarket.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence
    (
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(
                configuration.GetConnectionString("Default")));

        services
            .AddScoped<IApplicationDbContext, ApplicationDbContext>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IListingRepository, ListingRepository>()
            .AddScoped<IPhotoRepository, PhotoRepository>()
            .AddScoped<IReviewRepository, ReviewRepository>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
