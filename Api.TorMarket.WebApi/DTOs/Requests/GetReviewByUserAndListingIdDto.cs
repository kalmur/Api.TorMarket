using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record class GetReviewByUserAndListingIdDto
{
    [Required]
    public required int UserId { get; init; }

    [Required]
    public required int ListingId { get; init; }
}
