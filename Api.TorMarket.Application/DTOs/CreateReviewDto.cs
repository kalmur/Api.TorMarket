namespace Api.TorMarket.Application.DTOs;

public record CreateReviewDto(
    int UserId,
    int ListingId,
    int Rating,
    string Comment
);