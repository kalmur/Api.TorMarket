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
        ListingId = product.ListingId,
        CategoryId = product.CategoryId,
        Name = product.Name,
        Price = product.Price,
        Description = product.Description,
        BlobUrls = product.BlobUrls
    };

    public static ListingWithDetailsDto ToResponseDto(
        this ListingWithCategory model
    ) => new()
    {
        ListingId = model.ListingId,
        CategoryId = model.CategoryId,
        Name = model.Name ?? string.Empty,
        Price = model.Price,
        Description = model.Description,
        BlobUrls = model.BlobUrls,
        Category = model.Category?.ToResponseDto() ?? null,
        User = null
    };

    public static IEnumerable<ListingWithDetailsDto> ToResponseDto(
        this IEnumerable<ListingWithCategory> models
    ) => models.Select(ToResponseDto);

    public static ListingWithDetailsDto ToResponseDto(
        this ListingWithUserAndCategory model
    ) => new()
    {
        ListingId = model.ListingId,
        CategoryId = model.CategoryId,
        Name = model.Name,
        Price = model.Price,
        Description = model.Description,
        BlobUrls = model.BlobUrls,
        Category = model.Category?.ToResponseDto() ?? null,
        User = model.User?.ToResponseDto() ?? null
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
    };
}
