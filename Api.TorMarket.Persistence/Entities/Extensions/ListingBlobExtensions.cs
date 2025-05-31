using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ListingBlobExtensions
{
    public static ListingBlob ToModel(
        this ListingBlobEntity entity
    ) => new()
    {
        ListingBlobId = entity.ListingBlobId,
        ListingId = entity.ListingId,
        Url = entity.Url,
        IsPrimary = entity.IsPrimary
    };
}
