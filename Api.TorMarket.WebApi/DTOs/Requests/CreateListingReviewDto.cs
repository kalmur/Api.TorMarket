using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record CreateListingReviewDto
{
    [Required]
    [JsonPropertyName("userId")]
    public required int UserId { get; set; }

    [Required]
    [JsonPropertyName("listingId")]
    public required int ListingId { get; set; }

    [Required]
    [JsonPropertyName("value")]
    public required int Value { get; set; }

    [Required]
    [JsonPropertyName("comment")]
    public required string Comment { get; set; }
}
