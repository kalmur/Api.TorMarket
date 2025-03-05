namespace Api.TorMarket.Domain.Models;

public class Product
{
    public const int ProductName_MaxLength = 100;

    public int ProductId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset AvailableFrom { get; set; }
}
