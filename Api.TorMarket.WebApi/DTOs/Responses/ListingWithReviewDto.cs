namespace Api.TorMarket.WebApi.DTOs.Responses;

public record ListingWithReviewDto : ListingDto
{
    public required CategoryDto Category { get; init; }
    public required UserDto User { get; init; }
    public required ReviewDto Review { get; init; }
}
