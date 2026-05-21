using Api.TorMarket.Domain.Models.External;

namespace Api.TorMarket.Domain.Models.ViewModels;

public sealed record UserProfile
{
    public required User User { get; init; }
    public FusionAuthUser? IdentityProfile { get; init; }
}
