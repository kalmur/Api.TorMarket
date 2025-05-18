using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public record UpdateBlobUrlRequestDto
{
    [Required]
    public BlobUrlDto BlobUrl { get; init; }
}

public record BlobUrlDto
{
    [Required]
    public string Url { get; init; }
}
