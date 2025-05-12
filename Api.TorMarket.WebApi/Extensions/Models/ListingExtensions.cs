using Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;
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

    public static IEnumerable<ListingDto> ToResponseDto(
        this IEnumerable<Listing> listings
    ) => listings.Select(ToResponseDto);

    public static ListingWithDetailsDto ToResponseDto(
        this ListingWithUserAndCategory model
    ) => new()
    {
        ProductId = model.ListingId,
        CategoryId = model.CategoryId,
        Name = model.Name,
        Price = model.Price,
        Description = model.Description,
        AvailableFrom = model.AvailableFrom,
        Category = model.Category?.ToResponseDto(),
        User = model.User?.ToResponseDto()
    };

    public static IEnumerable<ListingWithDetailsDto> ToResponseDto(
        this IEnumerable<ListingWithUserAndCategory> models
    ) => models.Select(ToResponseDto);

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
}
