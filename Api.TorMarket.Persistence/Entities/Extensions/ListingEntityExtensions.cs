using Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;
using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ListingEntityExtensions
{
    internal static Listing ToModel(
        this ListingEntity entity
    ) => new()
    {

        ListingId = entity.ListingId,
        UserId = entity.UserId,
        CategoryId = entity.CategoryId,
        Name = entity.Name,
        Price = entity.Price,
        Description = entity.Description
    };

    internal static ListingWithUserAndCategory ToModelWithUserAndCategory(
        this ListingEntity entity
    ) => new()
    {
        ListingId = entity.ListingId,
        UserId = entity.UserId,
        CategoryId = entity.CategoryId,
        Name = entity.Name,
        Price = entity.Price,
        Description = entity.Description,
        User = entity.User.ToModel(),
        Category = entity.Category.ToModel()
    };

    internal static ListingWithCategory ToModelWithCategory(
        this ListingEntity entity
    ) => new()
    {
        ListingId = entity.ListingId,
        UserId = entity.UserId,
        CategoryId = entity.CategoryId,
        Name = entity.Name,
        Price = entity.Price,
        Description = entity.Description,
        Category = entity.Category.ToModel()
    };

    internal static ListingEntity ToEntity(
        this CreateListingRequest request
    ) => new()
    {
        UserId = request.UserId,
        CategoryId = request.CategoryId,
        Name = request.Name,
        Price = request.Price,
        Description = request.Description
    };

    internal static CreateListingRequest ToRequest(
        this CreateListingCommand command
    ) => new()
    {
        UserId = command.UserId,
        CategoryId = command.CategoryId,
        Name = command.Name,
        Price = command.Price,
        Description = command.Description,
    };

    internal static CreateUserRequest ToRequest(
        this CreateUserCommand command
    ) => new()
    {
        ProviderId = command.ProviderId
    };
}
