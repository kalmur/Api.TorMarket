using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public record CreateListingRequestDto
{
    [Required]
    public required int UserId { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(Listing.ListingNameMaxLength)]
    public required string Name { get; init; }

    [Required]
    public required int CategoryId { get; init; }

    [Required]
    public required decimal Price { get; init; }

    public string? Description { get; init; }

    public List<string>? FilePaths { get; init; }
}