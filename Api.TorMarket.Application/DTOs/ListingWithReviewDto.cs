namespace Api.TorMarket.Application.DTOs;

public record ListingWithReviewDto(
    ListingDto Listing,
    ReviewDto Review
);