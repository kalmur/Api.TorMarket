namespace Api.TorMarket.Application.Abstractions;

public interface IAuth0TokenCache
{
    ValueTask<string> GetTokenAsync(CancellationToken token = default);
}
