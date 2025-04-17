using Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;
using Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class ListingExtensions
{
    public static ListingDto ToResponseDto(
        this Listing product
    ) => new()
    {
        ProductId = product.ListingId,
        CategoryId = product.CategoryId,
        Name = product.Name,
        Price = product.Price,
        Description = product.Description,
        AvailableFrom = product.AvailableFrom
    };

    public static CreateListingCommand ToCommand(
        this CreateListingRequestDto request
    ) => new()
    {
        UserId = request.UserId,
        CategoryId = request.CategoryId,
        Name = request.Name,
        Price = request.Price,
        Description = request.Description,
        AvailableFrom = request.AvailableFrom
    };

    public static GetListingsByNameQuery ToGetByNameQuery(
        this string name
    ) => new(name);

    public static GetListingsByCategoryNameQuery ToGetByCategoryNameQuery(
        this string name
    ) => new(name);
}
