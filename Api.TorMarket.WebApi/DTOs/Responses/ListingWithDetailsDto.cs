namespace Api.TorMarket.WebApi.DTOs.Responses;

public record ListingWithDetailsDto : ListingDto
{
    public required ListingCategoryDto? Category { get; init; }
    public required UserDto? User { get; init; }
}
