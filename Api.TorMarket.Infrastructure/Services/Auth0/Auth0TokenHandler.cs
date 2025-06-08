using System.Net.Http.Headers;
using Api.TorMarket.Application.Abstractions;

namespace Api.TorMarket.Infrastructure.Services.Auth0;

public class Auth0TokenHandler : DelegatingHandler
{
    private const string Scheme = "Bearer";
    private readonly IAuth0TokenCache _cache;

    public Auth0TokenHandler(IAuth0TokenCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    ///     Adds an authentication header with a Auth0-generated JWT token.
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

