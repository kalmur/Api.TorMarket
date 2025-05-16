using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Domain.Models.External;

public record BlobInfo(
    [Required] Stream Content,
    [Required] string ContentType
);
