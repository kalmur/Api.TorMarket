using Newtonsoft.Json;

namespace Api.TorMarket.Domain.Model.External;

public class AccessTokenResponse
{
    /// <summary>
    ///     Identifier token.
    /// </summary>
    [JsonProperty("id_token")]
    public string? IdToken { get; set; }

    /// <summary>
    ///     Expiration time in seconds.
    /// </summary>
    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    ///     Refresh token.
    /// </summary>
    [JsonProperty("refresh_token")]
    public string? RefreshToken { get; set; }

    /// <summary>
    ///     Access token.
    /// </summary>
    [JsonProperty("access_token")]
    public string? AccessToken { get; set; }

    /// <summary>
    ///     Type of token.
    /// </summary>
    [JsonProperty("token_type")]
    public string? TokenType { get; set; }
}
