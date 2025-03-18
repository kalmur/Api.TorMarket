using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public record CreateProductRequestDto
{
    [Required]
    public required int UserId { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(Listing.ListingNameMaxLength)]
    public required string Name { get; set; }

    [Required]
    public required int CategoryId { get; set; }

    [Required]
    public required decimal Price { get; set; }

    public string? Description { get; set; }

    public DateTimeOffset AvailableFrom { get; set; }
}