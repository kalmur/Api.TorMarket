using Api.TorMarket.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.WebApi.DTOs.Requests;

public record CreateUserRequestDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(User.ProviderIdMaxLength)]
    public required string ProviderId { get; init; }
}