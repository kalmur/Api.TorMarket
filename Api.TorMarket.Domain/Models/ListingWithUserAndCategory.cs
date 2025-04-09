namespace Api.TorMarket.Domain.Models;

public class ListingWithUserAndCategory
{
    public const int ListingNameMaxLength = 100;

    public int ListingId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset AvailableFrom { get; set; }
    public User? User { get; set; }
    public ListingCategory? Category { get; set; }
}
