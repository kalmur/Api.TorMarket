using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record UpdateBlobUrlRequestDto
{
    [Required]
    public required BlobUrlDto BlobUrl { get; init; }
}

public sealed record BlobUrlDto
{
    [Required]
    public string Url { get; init; }
}
