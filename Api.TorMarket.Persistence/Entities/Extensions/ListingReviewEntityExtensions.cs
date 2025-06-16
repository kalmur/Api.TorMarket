using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Persistence.Entities.Extensions;

internal static class ListingReviewEntityExtensions
{
    internal static ListingWithReviewAndCategory ToModel(
        this ListingReviewEntity entity
    ) => new()
    {
        UserId = entity.UserId,
        ListingId = entity.ListingId,
        Value = entity.Rating,
        Comment = entity.Comment,
        Listing = entity.Listing.ToModel(),
        Category = entity.Listing.Category.ToModel()
    };

    internal static ListingReviewEntity ToEntity(
        this CreateListingReviewRequest request
    ) => new()
    {
        UserId = request.UserId,
        ListingId = request.ListingId,
        Rating = request.Value,
        Comment = request.Comment
    };
}
