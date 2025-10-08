namespace Api.TorMarket.Domain.Models.External;

public record SearchDocument
{
    public required int ListingId { get; init; }
    public required string ListingTitle { get; init; }
    public required string ListingDescription { get; init; }
}
