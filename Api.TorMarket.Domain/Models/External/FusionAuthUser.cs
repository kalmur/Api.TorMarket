using Newtonsoft.Json;

namespace Api.TorMarket.Domain.Models.External;

public record FusionAuthUser
{
    [JsonProperty("id")]
    public string? ExternalProviderId { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("lastName")]
    public string? LastName { get; set; }
}

public sealed record FusionAuthUserSearchResponse
{
    [JsonProperty("users")]
    public List<FusionAuthUser> Users { get; set; } = new();

    [JsonProperty("total")]
    public int Total { get; set; }
}
