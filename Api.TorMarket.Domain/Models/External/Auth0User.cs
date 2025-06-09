using Newtonsoft.Json;

namespace Api.TorMarket.Domain.Models.External;

public record Auth0User
{
    [JsonProperty("user_id")]
    public string? ExternalProviderId { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("given_name")]
    public string? FirstName { get; set; }

    [JsonProperty("family_name")]
    public string? LastName { get; set; }
}

