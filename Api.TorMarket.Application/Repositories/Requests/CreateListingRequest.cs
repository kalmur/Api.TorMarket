namespace Api.TorMarket.Application.Repositories.Requests;

public sealed record CreateListingRequest
{
    public required int UserId { get; set; }
    public required int CategoryId { get; set; }
    public required int CurrencyId { get; set; }
    public required string ListingName { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
}