namespace Api.TorMarket.Domain.Models.External;

public record SearchDocument
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
