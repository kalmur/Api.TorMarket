namespace Api.TorMarket.WebApi.DTOs.Responses;

public record ReviewDto
{
    public required int RatingValue { get; init; }
    public required string Comment { get; init; }
}
