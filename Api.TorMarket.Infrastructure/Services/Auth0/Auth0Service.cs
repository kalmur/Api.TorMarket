using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Text;
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
        var client = _httpClientFactory.CreateClient(ClientNames.Auth0Authentication);

        var body = new Dictionary<string, string>
        {
            { "client_id", _options.ClientId! },
            { "client_secret", _options.ClientSecret! },
            { "audience", _options.Audience! },
            { "grant_type", "client_credentials" }
        };
        var jsonBody = JsonConvert.SerializeObject(body);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

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