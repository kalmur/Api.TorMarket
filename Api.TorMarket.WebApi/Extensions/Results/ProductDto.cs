namespace Api.TorMarket.WebApi.Extensions.Results;

public record ProductDto
{
    public required int ProductId { get; set; }
    public required int CategoryId { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset AvailableFrom { get; set; }
}