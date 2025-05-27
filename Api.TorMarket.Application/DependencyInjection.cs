using Api.TorMarket.Application.CQRS;
using Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;
using Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;
using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.TorMarket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(
        this IServiceCollection services, 
        IConfiguration configuration
    ) => services
            .AddMediator()
            .AddValidators();

    private static IServiceCollection AddMediator(
        this IServiceCollection services
    ) => services
            .AddMediatR(config =>
                config.RegisterServicesFromAssembly(
                    typeof(DependencyInjection).Assembly
                )
            );

    private static IServiceCollection AddValidators(
        this IServiceCollection services
    ) => services
            .AddScoped<IValidator<CreateListingCommand, CreateListingFailure>, CreateListingValidator>()
            .AddScoped<IValidator<CreateListingReviewCommand, CreateListingReviewFailure>, CreateListingReviewValidator>()
            .AddScoped<IValidator<CreateUserCommand, CreateUserFailure>, CreateUserValidator>()
            .AddScoped<IValidator<GetCategoryByNameQuery, GetCategoryByNameFailure>, GetCategoryByNameValidator>()
            .AddScoped<IValidator<GetListingsByNameQuery, GetListingsByNameFailure>, GetListingByNameValidator>()
            .AddScoped<IValidator<GetListingsByProviderIdQuery, GetListingsByProviderIdFailure>, GetListingsByProviderIdValidator>();
}
