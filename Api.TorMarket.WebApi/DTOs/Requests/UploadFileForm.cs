using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record UploadFileForm
{
    [Required]
    [JsonPropertyName("file")]
    public required IFormFile File { get; set; }
}