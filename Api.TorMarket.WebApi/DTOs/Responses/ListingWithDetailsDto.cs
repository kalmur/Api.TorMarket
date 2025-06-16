namespace Api.TorMarket.WebApi.DTOs.Responses;

public record ListingWithDetailsDto
{
    public required int ListingId { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required string? Description { get; init; }
    public required CategoryDto? Category { get; init; }
    public required UserDto? User { get; init; }
    public required IEnumerable<ListingBlobDto>? ListingBlobs { get; init; }
}
