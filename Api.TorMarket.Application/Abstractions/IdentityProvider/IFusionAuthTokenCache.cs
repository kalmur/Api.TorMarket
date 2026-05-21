namespace Api.TorMarket.Application.Abstractions.IdentityProvider;

public interface IFusionAuthTokenCache
{
    ValueTask<string> GetTokenAsync(CancellationToken token = default);
}
