using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record ExchangeCodeRequestDto
{
    [Required(AllowEmptyStrings = false)]
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    [JsonPropertyName("redirectUri")]
    public string? RedirectUri { get; init; }

    [JsonPropertyName("codeVerifier")]
    public string? CodeVerifier { get; init; }
}
