namespace Api.TorMarket.Application.Models;

public record PhotoModel(
    int PhotoId,
    int UserId,
    int ListingId,
    string Url,
    bool IsPrimary
);