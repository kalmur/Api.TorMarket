using Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;
using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ListingEntityExtensions
{
    public static Listing ToModel(
        this ListingEntity entity
    ) => new()
    {

        ListingId = entity.ListingId,
        UserId = entity.UserId,
        CategoryId = entity.CategoryId,
        Name = entity.Name,
        Price = entity.Price,
        Description = entity.Description,
        BlobUrls = entity.BlobUrls
    };

    public static ListingWithUserAndCategory ToModelWithUserAndCategory(
        this ListingEntity entity
    ) => new()
    {
        ListingId = entity.ListingId,
        UserId = entity.UserId,
        CategoryId = entity.CategoryId,
        Name = entity.Name,
        Price = entity.Price,
        Description = entity.Description,
        BlobUrls = entity.BlobUrls,
        User = entity.User.ToModel(),
        Category = entity.ListingCategory.ToModel()
    };

    public static ListingWithCategory ToModelWithCategory(
        this ListingEntity entity
    ) => new()
    {
        ListingId = entity.ListingId,
        UserId = entity.UserId,
        CategoryId = entity.CategoryId,
        Name = entity.Name,
        Price = entity.Price,
        Description = entity.Description,
        BlobUrls = entity.BlobUrls,
        Category = entity.ListingCategory.ToModel()
    };

    public static ListingEntity ToEntity(
        this CreateListingRequest request
    ) => new()
    {
        UserId = request.UserId,
        CategoryId = request.CategoryId,
        Name = request.Name,
        Price = request.Price,
        Description = request.Description,
        BlobUrls = null
    };

    public static CreateListingRequest ToRequest(
        this CreateListingCommand command
    ) => new()
    {
        UserId = command.UserId,
        CategoryId = command.CategoryId,
        Name = command.Name,
        Price = command.Price,
        Description = command.Description,
    };

    public static CreateUserRequest ToRequest(
        this CreateUserCommand command
    ) => new()
    {
        ProviderId = command.ProviderId
    };
}
