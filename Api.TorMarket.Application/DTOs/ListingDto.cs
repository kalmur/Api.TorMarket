namespace Api.TorMarket.Application.DTOs;

public record ListingDto(
    int ListingId,
    int UserId,
    int CategoryId,
    string Name,
    int SellLease,
    string? Description,
    int Price,
    string City,
    string Country,
    DateTime? AvailableFrom
);
