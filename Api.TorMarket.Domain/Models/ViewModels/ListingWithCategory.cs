namespace Api.TorMarket.Domain.Models.ViewModels;

public record ListingWithCategory : Listing
{
    public Category? Category { get; set; }
}
