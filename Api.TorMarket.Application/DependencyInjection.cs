using System.Runtime.CompilerServices;
using Api.TorMarket.Application.Workflows;
using Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;
using Api.TorMarket.Application.Workflows.Product.Queries.GetCategoryByName;
using Api.TorMarket.Application.Workflows.User.Commands.CreateUser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.TorMarket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services, 
        IConfiguration configuration
    ) => services
            .AddMediator()
            .AddValidators();

    private static IServiceCollection AddMediator(
        this IServiceCollection services
    ) => services.AddMediatR(config =>
        config.RegisterServicesFromAssembly(
            typeof(DependencyInjection).Assembly
        )
    );

    private static IServiceCollection AddValidators(
        this IServiceCollection services
    ) => services
            .AddScoped<IValidator<CreateProductCommand, CreateProductFailure>, CreateProductValidator>()
            .AddScoped<IValidator<CreateUserCommand, CreateUserFailure>, CreateUserValidator>()
            .AddScoped<IValidator<GetCategoryByNameQuery, GetCategoryByNameFailure>, GetCategoryByNameValidator>();
}
