using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Infrastructure.Models;

public record BlobInfo(
    [Required] Stream Content,
    [Required] string ContentType
);
