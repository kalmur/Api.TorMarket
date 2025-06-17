using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record UploadContentRequest
{
    [Required]
    [JsonPropertyName("content")]
    public required string Content { get; init; }

    [Required]
    [JsonPropertyName("fileName")]
    public required string FileName { get; init; }
}