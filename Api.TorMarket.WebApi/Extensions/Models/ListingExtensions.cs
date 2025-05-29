using Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;
using Api.TorMarket.Application.CQRS.Commands.Listings.UpdateListingBlobUrls;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.ViewModels;
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
        Description = product.Description
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

    public static UpdateListingBlobUrlsCommand ToCommand(
        this UpdateBlobUrlRequestDto request,
        int listingId
    ) 
        => new(
            listingId, 
            request.BlobUrl.Url
        );
}
