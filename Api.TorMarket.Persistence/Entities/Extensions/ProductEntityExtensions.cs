using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Workflows.Listings.Commands.CreateListing;
using Api.TorMarket.Application.Workflows.Users.Commands.CreateUser;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ProductEntityExtensions
{
    internal static Listing ToModel(
        this ListingEntity entity
    ) => new Listing
    {
        ListingId = entity.ListingId,
        UserId = entity.UserId,
        CategoryId = entity.CategoryId,
        Name = entity.Name,
        Price = entity.Price,
        Description = entity.Description,
        AvailableFrom = entity.AvailableFrom
    };

    internal static ListingEntity ToEntity(
        this CreateListingRequest request
    ) => new ListingEntity
    {
        UserId = request.UserId,
        CategoryId = request.CategoryId,
        Name = request.Name,
        Price = request.Price,
        Description = request.Description,
        AvailableFrom = request.AvailableFrom
    };

    internal static CreateListingRequest ToRequest(
        this CreateListingCommand command
    ) => new CreateListingRequest
    {
        UserId = command.UserId,
        CategoryId = command.CategoryId,
        Name = command.Name,
        Price = command.Price,
        Description = command.Description,
        AvailableFrom = command.AvailableFrom
    };

    internal static CreateUserRequest ToRequest(
        this CreateUserCommand command
    ) => new CreateUserRequest
    {
        ProviderId = command.ProviderId
    };
}
