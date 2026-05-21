using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Domain.Models.External;
using Api.TorMarket.Application.Abstractions.IdentityProvider;

namespace Api.TorMarket.Infrastructure.Services.FusionAuth;

public class FusionAuthService : IIdentityProviderService
{
    private readonly IFusionAuthQueryBuilder _queryBuilder;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly FusionAuthConfig _options;

    public FusionAuthService(
        IFusionAuthQueryBuilder queryBuilder,
        IHttpClientFactory httpClientFactory,
        IOptions<FusionAuthConfig> options
    )
    {
        _queryBuilder = queryBuilder;
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    public async Task<IReadOnlyCollection<FusionAuthUser>> GetUsersInformationAsync(
        IReadOnlyCollection<string> providerIds,
        CancellationToken token = default
    )
    {
        var client = _httpClientFactory.CreateClient(ClientNames.FusionAuth);

        var query = _queryBuilder.GenerateQueryString(providerIds);

        var response = await client.GetAsync(
            $"{_options.GetUsersEndpoint}?{query}",
            token
        );

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync(token);
            var searchResponse = JsonConvert.DeserializeObject<FusionAuthUserSearchResponse>(content);
            return searchResponse?.Users ?? new List<FusionAuthUser>();
        }

        return new List<FusionAuthUser>();
    }

    public async Task<AccessTokenResponse> RetrieveAccessTokenAsync(
        CancellationToken token = default
    )
    {
        var client = _httpClientFactory.CreateClient(ClientNames.FusionAuthAuthentication);

        // FusionAuth's /oauth2/token endpoint expects application/x-www-form-urlencoded.
        var body = new Dictionary<string, string>
        {
            { "client_id", _options.ClientId! },
            { "client_secret", _options.ClientSecret! },
            { "scope", _options.Audience! },
            { "grant_type", "client_credentials" }
        };
        var content = new FormUrlEncodedContent(body);

        var response = await client.PostAsync($"{_options.AuthenticationEndpoint}", content, token);

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
}
