using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record GetReviewByUserAndListingIdDto
{
    [Required]
    [JsonPropertyName("userId")]
    public required int UserId { get; init; }

    [Required]
    [JsonPropertyName("listingId")]
    public required int ListingId { get; init; }
}
