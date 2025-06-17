namespace Api.TorMarket.Application.Abstractions.IdentityProvider;

public interface IAuth0TokenCache
{
    ValueTask<string> GetTokenAsync(CancellationToken token = default);
}
