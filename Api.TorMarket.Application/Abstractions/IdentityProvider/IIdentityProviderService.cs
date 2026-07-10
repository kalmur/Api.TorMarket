using Api.TorMarket.Domain.Models.External;

namespace Api.TorMarket.Application.Abstractions.IdentityProvider;

public interface IIdentityProviderService
{
    Task<IReadOnlyCollection<Auth0User>> GetUsersInformationAsync(
        IReadOnlyCollection<string> providerIds, 
        CancellationToken token = default
    );

    Task<AccessTokenResponse> RetrieveAccessTokenAsync(
        CancellationToken token = default
    );

    /// <summary>
    ///     Exchanges an authorization code (Authorization Code flow, with or without PKCE)
    ///     for access, id and refresh tokens.
    /// </summary>
    /// <param name="code">The authorization code returned to the redirect URI.</param>
    /// <param name="redirectUri">
    ///     The redirect URI registered with the identity provider. If null, the configured
    ///     default redirect URI is used.
    /// </param>
    /// <param name="codeVerifier">The PKCE code verifier, when PKCE is used.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<AccessTokenResponse> ExchangeAuthorizationCodeAsync(
        string code,
        string? redirectUri = null,
        string? codeVerifier = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Exchanges a refresh token for a new access token (and optionally a rotated refresh token).
    /// </summary>
    /// <param name="refreshToken">A previously issued refresh token.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task<AccessTokenResponse> RefreshAccessTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Revokes a refresh token at the identity provider so it can no longer be used.
    /// </summary>
    /// <param name="refreshToken">The refresh token to revoke.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    Task RevokeRefreshTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken = default
    );
}
