using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class ListingBlobExtensions
{
    public static ListingBlobDto ToResponseDto(
        this ListingBlob listingBlob
    ) => new()
    {
        Url = listingBlob.Url,
        IsPrimary = listingBlob.IsPrimary
    };
}
