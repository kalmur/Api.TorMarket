using Newtonsoft.Json;

namespace Api.TorMarket.Domain.Models.External;

public class Auth0User
{
    public Auth0User(string? externalProviderId, string? firstName, string? lastName)
    {
        ExternalProviderId = externalProviderId;
        FirstName = firstName;
        LastName = lastName;
    }

    [JsonProperty("user_id")]
    public string? ExternalProviderId { get; set; }

    [JsonProperty("given_name")]
    public string? FirstName { get; set; }

    [JsonProperty("family_name")]
    public string? LastName { get; set; }
}

