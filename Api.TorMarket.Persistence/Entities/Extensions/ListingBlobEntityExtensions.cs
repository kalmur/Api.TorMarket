using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ListingBlobEntityExtensions
{
    internal static void AddBlob(
        this ICollection<ListingBlobEntity> listingBlobs,
        int listingId,
        string blobUrl,
        bool isPrimary
    )
    {
        if (string.IsNullOrWhiteSpace(blobUrl))
            throw new ArgumentException("Blob URL cannot be null or empty.", nameof(blobUrl));

        if (blobUrl.Length > ListingBlob.Url_MaxLength)
            throw new ArgumentException($"Blob URL exceeds maximum length of {ListingBlob.Url_MaxLength}.", nameof(blobUrl));

        var listingBlob = new ListingBlobEntity
        {
            ListingId = listingId,
            Url = blobUrl,
            IsPrimary = isPrimary
        };

        listingBlobs.Add(listingBlob);
    }
}
