namespace Api.TorMarket.Application.Models;

public record ReviewModel(
    int ReviewId,
    int UserId,
    int ListingId,
    int Rating,
    string? Comment
);