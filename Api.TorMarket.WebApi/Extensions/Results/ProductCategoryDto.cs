namespace Api.TorMarket.WebApi.Extensions.Results;

public record ProductCategoryDto
{
    public required int ProductCategoryId { get; init; }
    public required string Name { get; init; }
}
