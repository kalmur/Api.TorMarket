using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Domain.Models.External;
using Api.TorMarket.Application.Abstractions.IdentityProvider;

namespace Api.TorMarket.Infrastructure.Services.Auth0;

public class Auth0Service : IIdentityProviderService
{
    private readonly IAuth0QueryBuilder _queryBuilder;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Auth0Config _options;

    public Auth0Service(
        IAuth0QueryBuilder queryBuilder,
        IHttpClientFactory httpClientFactory,
        IOptions<Auth0Config> options
    )
    {
        _queryBuilder = queryBuilder;
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    public async Task<IReadOnlyCollection<Auth0User>> GetUsersInformationAsync(
        IReadOnlyCollection<string> providerIds,
        CancellationToken token = default
    )
    {
        var client = _httpClientFactory.CreateClient(ClientNames.Auth0);
        var query = _queryBuilder.GenerateQueryString(providerIds);

        var response = await client.GetAsync(
            $"{_options.GetUsersEndpoint}?{query}",
            token
        );

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<List<Auth0User>>(content)!;
        }

        return new List<Auth0User>();
    }

    public async Task<AccessTokenResponse> RetrieveAccessTokenAsync(
        CancellationToken token = default
    )
    {
        var body = new Dictionary<string, string>
        {
            { "client_id", _options.ClientId! },
            { "client_secret", _options.ClientSecret! },
            { "audience", _options.Audience! },
            { "grant_type", "client_credentials" }
        };
        var content = new FormUrlEncodedContent(body);

        var client = _httpClientFactory.CreateClient(ClientNames.Auth0Authentication);
        var response = await client.PostAsync($"https://{_options.Domain}/oauth/token", content, token);

        var responseContent = await response.Content.ReadAsStringAsync(token);
        var tokenObject = JsonConvert.DeserializeObject<AccessTokenResponse>(responseContent);

        if (response.IsSuccessStatusCode && tokenObject is not null)
        {
            return tokenObject;
        }
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            return new AccessTokenResponse();
        }

        return new AccessTokenResponse();
    }

    public async Task<AccessTokenResponse> ExchangeAuthorizationCodeAsync(
        string code,
        string? redirectUri = null,
        string? codeVerifier = null,
        CancellationToken cancellationToken = default
    )
    {
        var body = new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "client_id", _options.SpaClientId! },
            { "code", code },
            { "redirect_uri", redirectUri ?? _options.RedirectUri ?? string.Empty }
        };

        if (!string.IsNullOrWhiteSpace(codeVerifier))
        {
            body["code_verifier"] = codeVerifier;
        }
        else
        {
            body["client_secret"] = _options.ClientSecret!;
        }

        return await PostTokenRequestAsync(body, cancellationToken);
    }

    public async Task<AccessTokenResponse> RefreshAccessTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken = default
    )
    {
        var body = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "client_id", _options.SpaClientId! },
            { "refresh_token", refreshToken }
        };

        return await PostTokenRequestAsync(body, cancellationToken);
    }

    public async Task RevokeRefreshTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken = default
    )
    {
        var body = new Dictionary<string, string>
        {
            { "client_id", _options.SpaClientId! },
            { "token", refreshToken }
        };

        var content = new FormUrlEncodedContent(body);

        var client = _httpClientFactory.CreateClient(ClientNames.Auth0Authentication);
        await client.PostAsync($"https://{_options.Domain}/oauth/revoke", content, cancellationToken);
    }

    private async Task<AccessTokenResponse> PostTokenRequestAsync(
        IDictionary<string, string> body,
        CancellationToken cancellationToken
    )
    {
        var client = _httpClientFactory.CreateClient(ClientNames.Auth0Authentication);
        var content = new FormUrlEncodedContent(body);

        var response = await client.PostAsync($"https://{_options.Domain}/oauth/token", content, cancellationToken);

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var tokenObject = JsonConvert.DeserializeObject<AccessTokenResponse>(responseContent);

        if (response.IsSuccessStatusCode && tokenObject is not null)
        {
            return tokenObject;
        }

        return tokenObject ?? new AccessTokenResponse
        {
            Error = "server_error",
            ErrorDescription = "The identity provider returned an unexpected response."
        };
    }
}