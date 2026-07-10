using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Domain.Models.External;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public sealed class AuthController : ControllerBase
{
    internal const string RefreshTokenCookieName = "tm.rt";
    private const string CookiePath = "/api";
    private static readonly TimeSpan RefreshTokenCookieLifetime = TimeSpan.FromDays(30);

    private readonly IWebHostEnvironment _environment;

    public AuthController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    /// <summary>
    ///     Exchanges an OAuth 2.0 authorization code (Authorization Code flow with PKCE)
    ///     for an access token. The refresh token is stored in an HttpOnly cookie and
    ///     never exposed to JavaScript.
    /// </summary>
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> ExchangeCodeAsync(
        [FromServices] IIdentityProviderService identityProviderService,
        [FromBody][Required] ExchangeCodeRequestDto request,
        CancellationToken cancellationToken
    )
    {
        var tokenResponse = await identityProviderService.ExchangeAuthorizationCodeAsync(
            request.Code,
            request.RedirectUri,
            request.CodeVerifier,
            cancellationToken
        );

        return ToTokenResponseResult(tokenResponse);
    }

    /// <summary>
    ///     Issues a new access token using the refresh token stored in the HttpOnly cookie.
    /// </summary>
    [HttpPost("refresh")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponseDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> RefreshAsync(
        [FromServices] IIdentityProviderService identityProviderService,
        CancellationToken cancellationToken
    )
    {
        if (!Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken)
            || string.IsNullOrWhiteSpace(refreshToken))
        {
            return MissingOrInvalidRefreshToken();
        }

        var tokenResponse = await identityProviderService.RefreshAccessTokenAsync(
            refreshToken,
            cancellationToken
        );

        return ToTokenResponseResult(tokenResponse);
    }

    /// <summary>
    ///     Revokes the refresh token at the identity provider and clears the HttpOnly cookie.
    /// </summary>
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> LogoutAsync(
        [FromServices] IIdentityProviderService identityProviderService,
        CancellationToken cancellationToken
    )
    {
        if (Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken)
            && !string.IsNullOrWhiteSpace(refreshToken))
        {
            await identityProviderService.RevokeRefreshTokenAsync(refreshToken, cancellationToken);
        }

        ClearRefreshTokenCookie();

        return NoContent();
    }

    private IActionResult ToTokenResponseResult(AccessTokenResponse tokenResponse)
    {
        if (string.IsNullOrEmpty(tokenResponse.AccessToken))
        {
            ClearRefreshTokenCookie();

            var detail = !string.IsNullOrEmpty(tokenResponse.ErrorDescription)
                ? tokenResponse.ErrorDescription
                : !string.IsNullOrEmpty(tokenResponse.Error)
                    ? tokenResponse.Error
                    : "The identity provider did not return an access token.";

            return Unauthorized(
                new ProblemDetails
                {
                    Title = "Authentication failed.",
                    Detail = detail,
                    Status = StatusCodes.Status401Unauthorized
                }
            );
        }

        if (!string.IsNullOrEmpty(tokenResponse.RefreshToken))
        {
            SetRefreshTokenCookie(tokenResponse.RefreshToken);
        }

        return Ok(
            new TokenResponseDto
            {
                AccessToken = tokenResponse.AccessToken,
                IdToken = tokenResponse.IdToken,
                TokenType = tokenResponse.TokenType,
                ExpiresIn = tokenResponse.ExpiresIn
            }
        );
    }

    private void SetRefreshTokenCookie(string refreshToken)
    {
        var isSecure = !_environment.IsDevelopment();

        Response.Cookies.Append(
            RefreshTokenCookieName,
            refreshToken,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = isSecure,
                SameSite = isSecure ? SameSiteMode.None : SameSiteMode.Lax,
                Path = CookiePath,
                Expires = DateTimeOffset.UtcNow.Add(RefreshTokenCookieLifetime),
                IsEssential = true
            }
        );
    }

    private void ClearRefreshTokenCookie()
    {
        var isSecure = !_environment.IsDevelopment();

        Response.Cookies.Delete(
            RefreshTokenCookieName,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = isSecure,
                SameSite = isSecure ? SameSiteMode.None : SameSiteMode.Lax,
                Path = CookiePath
            }
        );
    }

    private IActionResult MissingOrInvalidRefreshToken() =>
        Unauthorized(
            new ProblemDetails
            {
                Title = "Authentication required.",
                Detail = "No valid refresh token is present. Sign in again.",
                Status = StatusCodes.Status401Unauthorized
            }
        );
}
