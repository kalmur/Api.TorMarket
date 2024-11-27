namespace Api.TorMarket.Application.DTOs;

public record CreateListingDto(
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
