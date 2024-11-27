namespace Api.TorMarket.Application.Models;

public record ListingModel(
    int ListingId,
    int UserId,
    int CategoryId,
    string Name,
    int SellLease,
    string? Description,
    int Price,
    string City,
    int? Rating,
    DateTime? AvailableFrom
);