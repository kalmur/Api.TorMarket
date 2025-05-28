using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record UploadContentRequest
{
    [Required]
    public required string Content { get; init; }

    [Required]
    public required string FileName { get; init; }
}