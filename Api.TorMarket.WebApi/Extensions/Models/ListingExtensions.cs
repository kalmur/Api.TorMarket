using Api.TorMarket.Application.Workflows.Listings.Commands.CreateListing;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.Extensions.Results;

namespace Api.TorMarket.WebApi.Extensions.Models;

internal static class ListingExtensions
{
    internal static ListingDto ToResponseDto(
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

    internal static CreateListingCommand ToCommand(this CreateListingRequestDto request)
    {
        return new CreateListingCommand
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            AvailableFrom = request.AvailableFrom
        };
    }
}
