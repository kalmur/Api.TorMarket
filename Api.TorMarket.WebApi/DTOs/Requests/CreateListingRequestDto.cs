using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record CreateListingRequestDto
{
    [Required]
    public required int UserId { get; init; }

    [Required]
    public required string CategoryName { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(Listing.Name_MaxLength)]
    public required string ListingName { get; init; }

    [Required]
    public required decimal Price { get; init; }
    
    [StringLength(Listing.Description_MaxLength)]
    public string? Description { get; init; }
}