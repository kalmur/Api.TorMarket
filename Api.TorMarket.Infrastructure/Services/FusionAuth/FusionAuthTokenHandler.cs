using System.Net.Http.Headers;
using Api.TorMarket.Application.Abstractions.IdentityProvider;

namespace Api.TorMarket.Infrastructure.Services.FusionAuth;

public class FusionAuthTokenHandler : DelegatingHandler
{
    private const string Scheme = "Bearer";

    private readonly IFusionAuthTokenCache _cache;

    public FusionAuthTokenHandler(IFusionAuthTokenCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    ///     Adds an authentication header with a FusionAuth-issued JWT token.
    /// </summary>
    /// <param name="request">The HTTP request that requires an authentication header.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>An HTTP response message.</returns>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue(Scheme, await _cache.GetTokenAsync(cancellationToken));
        return await base.SendAsync(request, cancellationToken);
    }
}
