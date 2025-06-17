using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record UploadFileRequest
{
    [Required]
    [JsonPropertyName("filePath")]
    public required string FilePath { get; init; }

    [Required]
    [JsonPropertyName("fileName")]
    public required string FileName { get; init; }
}
