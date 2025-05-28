using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record UploadFileRequest
{
    [Required]
    public required string FilePath { get; init; }

    [Required]
    public required string FileName { get; init; }
}
