using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;
using Api.TorMarket.Application.Workflows.User.Commands.CreateUser;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Extensions;

public static class ProductEntityExtensions
{
    public static Listing ToModel(this ListingEntity entity)
    {
        return new Listing
        {
            ListingId = entity.ListingId,
            UserId = entity.UserId,
            CategoryId = entity.CategoryId,
            Name = entity.Name,
            Price = entity.Price,
            Description = entity.Description,
            AvailableFrom = entity.AvailableFrom
        };
    }

    public static ListingEntity ToEntity(this CreateListingRequest request)
    {
        return new ListingEntity
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            AvailableFrom = request.AvailableFrom
        };
    }

    public static CreateListingRequest ToRequest(this CreateProductCommand command)
    {
        return new CreateListingRequest
        {
            UserId = command.UserId,
            CategoryId = command.CategoryId,
            Name = command.Name,
            Price = command.Price,
            Description = command.Description,
            AvailableFrom = command.AvailableFrom
        };
    }

    public static CreateUserRequest ToRequest(this CreateUserCommand command)
    {
        return new CreateUserRequest
        {
            ProviderId = command.ProviderId
        };
    }
}
