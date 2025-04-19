using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public record CreateListingReviewDto
{
    [Required]
    public required int UserId { get; set; }
    [Required]
    public required int ListingId { get; set; }
    [Required]
    public required int Value { get; set; }
    [Required]
    public required string Comment { get; set; }
}
