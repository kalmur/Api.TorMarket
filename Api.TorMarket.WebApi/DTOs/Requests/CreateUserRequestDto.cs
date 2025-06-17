using Api.TorMarket.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public sealed record CreateUserRequestDto
{
    [Required]
    [JsonPropertyName("roleId")]
    public required int RoleId { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(User.ProviderId_MaxLength)]
    [JsonPropertyName("providerId")]
    public required string ProviderId { get; init; }
}