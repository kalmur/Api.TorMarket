using Azure.Storage.Blobs.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Infrastructure.Models;

public record BlobInfo(
    [Required] Stream Content,
    [Required] string ContentType
);
