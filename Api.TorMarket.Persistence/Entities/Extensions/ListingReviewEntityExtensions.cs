using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ListingReviewEntityExtensions
{
    public static ListingWithReviewAndCategory ToModel(
        this ListingReviewEntity entity
    ) => new()
    {
        UserId = entity.UserId,
        ListingId = entity.ListingId,
        Value = entity.Value,
        Comment = entity.Comment,
        Listing = entity.Listing.ToModel(),
        Category = entity.Listing.ListingCategory.ToModel()
    };

    public static ListingReviewEntity ToEntity(
        this CreateListingReviewRequest request
    ) => new()
    {
        UserId = request.UserId,
        ListingId = request.ListingId,
        Value = request.Value,
        Comment = request.Comment
    };
}
