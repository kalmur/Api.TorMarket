namespace Api.TorMarket.WebApi.DTOs.Responses;

public record ListingWithReviewDto : ListingDto
{
    public required ListingCategoryDto Category { get; init; }
    public required UserDto User { get; init; }
    public required ReviewDto Review { get; init; }
}
