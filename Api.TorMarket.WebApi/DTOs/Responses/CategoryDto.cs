namespace Api.TorMarket.WebApi.DTOs.Responses;

public record CategoryDto
{
    public required int CategoryId { get; init; }
    public required string Name { get; init; }
}
