using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record UpdateBlobUrlRequestDto
{
    [Required]
    [JsonPropertyName("blobUrl")]
    public required BlobUrlDto BlobUrl { get; init; }
}

public sealed record BlobUrlDto
{
    [Required]
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
