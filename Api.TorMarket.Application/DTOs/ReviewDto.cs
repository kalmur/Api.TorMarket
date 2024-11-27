namespace Api.TorMarket.Application.DTOs;

public record ReviewDto(
    int ReviewId,
    int UserId,
    int ListingId,
    int? Rating,
    string Comment
);
