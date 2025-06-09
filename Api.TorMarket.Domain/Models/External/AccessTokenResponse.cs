using Newtonsoft.Json;

namespace Api.TorMarket.Domain.Models.External;

public class AccessTokenResponse
{
    [JsonProperty("id_token")]
    public string? IdToken { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("refresh_token")]
    public string? RefreshToken { get; set; }

    [JsonProperty("access_token")]
    public string? AccessToken { get; set; }

    [JsonProperty("token_type")]
    public string? TokenType { get; set; }
}
