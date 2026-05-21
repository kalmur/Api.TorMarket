using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Infrastructure.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ZiggyCreatures.Caching.Fusion;

namespace Api.TorMarket.Infrastructure.Services.FusionAuth.Cache;

public class FusionAuthTokenCache : IFusionAuthTokenCache
{
    private static string Key(string audience) => $"{nameof(FusionAuthTokenCache)}-{audience}";

    private const double TokenExpiryBuffer = 0.01d;

    private readonly IFusionCache _cache;
    private readonly IIdentityProviderService _fusionAuthService;
    private readonly FusionAuthConfig _options;

    public FusionAuthTokenCache(
        ILogger<FusionAuthTokenCache> logger,
        IFusionCacheProvider provider,
        IIdentityProviderService fusionAuthService,
        IOptions<FusionAuthConfig> options
    )
    {
        _cache = provider.GetCache(Constants.FusionCacheInstance);
        _fusionAuthService = fusionAuthService;
        _options = options.Value;
    }

    /// <summary>
    ///     Retrieves the Token from the cache if exists, or sets it if not.
    /// </summary>
    /// <param name="token">A cancellation token.</param>
    /// <returns>The access token as a string./></returns>
    public async ValueTask<string> GetTokenAsync(CancellationToken token = default)
    {
        return (await _cache.GetOrSetAsync<string>(Key(_options!.Audience!), async (config, ct) =>
        {
            var tokenResponse = await _fusionAuthService.RetrieveAccessTokenAsync(ct);

            var accessToken = tokenResponse.AccessToken;

            var computedExpiry = Math.Ceiling(tokenResponse.ExpiresIn - tokenResponse.ExpiresIn * TokenExpiryBuffer);

            var expiry = TimeSpan.FromSeconds(computedExpiry);

            config.Options.SetDuration(expiry);
            config.Options.SetEagerRefresh(0.95f);

            return accessToken;
        }, token: token))!;
    }
}
