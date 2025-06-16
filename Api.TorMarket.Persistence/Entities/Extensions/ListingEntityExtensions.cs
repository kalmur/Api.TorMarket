using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;

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
        Title = entity.Title,
        Price = entity.Price,
        Description = entity.Description
    };

    internal static ListingWithDetails ToListingWithDetails(
        this ListingEntity entity
    ) => new()
    {
        ListingId = entity.ListingId,
        UserId = entity.UserId,
        CategoryId = entity.CategoryId,
        Title = entity.Title,
        Price = entity.Price,
        Description = entity.Description,
        User = entity.User.ToModel() ?? null,
        Category = entity.Category.ToModel() ?? null,
        ListingBlobs = entity.ListingBlobs.Select(
            blob => blob.ToModel()
        ).ToList()
    };

    internal static ListingEntity ToEntity(
        this CreateListingRequest request
    ) => new()
    {
        UserId = request.UserId,
        CategoryId = request.CategoryId,
        Title = request.ListingName,
        Price = request.Price,
        Description = request.Description
    };

    internal static CreateUserRequest ToRequest(
        this CreateUserCommand command
    ) => new()
    {
        RoleId = command.RoleId,
        ProviderId = command.ProviderId
    };
}
