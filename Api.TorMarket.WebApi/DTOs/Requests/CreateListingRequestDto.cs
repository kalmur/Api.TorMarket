using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record CreateListingRequestDto
{
    [Required]
    [JsonPropertyName("userId")]
    public required int UserId { get; init; }

    [Required]
    [JsonPropertyName("categoryName")]
    public required string CategoryName { get; init; }

    [Required]
    [JsonPropertyName("currencyCode")]
    public required string CurrencyCode { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(Listing.Name_MaxLength)]
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [Required]
    [JsonPropertyName("price")]
    public required decimal Price { get; init; }
    
    [StringLength(Listing.Description_MaxLength)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}