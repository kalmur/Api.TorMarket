namespace Api.TorMarket.Domain.Models.ViewModels;

public record ListingWithUserAndCategory : Listing
{
    public User? User { get; set; }
    public Category? Category { get; set; }
}
