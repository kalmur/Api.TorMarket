using Api.User.Notes.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Api.TorMarket.Infrastructure.Options;

namespace Api.TorMarket.Infrastructure.Services.Auth0;

public class Auth0Service : IIdentityProviderService
{
    private readonly ILogger<Auth0Service> _logger;
    private readonly IAuth0QueryBuilder _queryBuilder;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Auth0Config _options;

    public Auth0Service(
        ILogger<Auth0Service> logger,
        IAuth0QueryBuilder queryBuilder,
        IHttpClientFactory httpClientFactory,
        IOptions<Auth0Config> options
    )
    {
        _logger = logger;
        _queryBuilder = queryBuilder;
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    /// <summary>
    ///     Performs an HTTP call to retrieves User information from Auth0.
    /// </summary>
    /// <param name="externalProviderIds">The Id's of the Users to be retrieved.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A list <see cref="Auth0User"/> containing user information.</returns>
    public async Task<IReadOnlyCollection<Auth0User>> GetUsersInformationAsync(
        IReadOnlyCollection<string> externalProviderIds,
        CancellationToken token = default)
    {
        var client = _httpClientFactory.CreateClient(ClientNames.Auth0);

        var query = _queryBuilder.GenerateQueryString(externalProviderIds);

        var response = await client.GetAsync($"{_options.GetUsersEndpoint}?{query}", token);

        if (response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Successfully retrieved users with IDs: {externalIds} from Auth0.",
                externalProviderIds);
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<List<Auth0User>>(content)!;
        }

        _logger.LogInformation("Could not retrieve users with IDs: {externalIds} from Auth0.", externalProviderIds);
        return new List<Auth0User>();
    }

    /// <summary>
    ///     Performs an HTTP call to retrieve an Access Token for authorization on Auth0.
    /// </summary>
    /// <param name="token">A cancellation token.</param>
    /// <returns>An <see cref="AccessTokenResponse"/> containing the Access Token.</returns>
    public async Task<AccessTokenResponse> RetrieveAccessTokenAsync(CancellationToken token = default)
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
            _logger.LogInformation("Successfully retrieved the Access Token from Auth0.");
            return tokenObject;
        }
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _logger.LogInformation("Unauthorized to retrieve the Access Token from Auth0.");
            return new AccessTokenResponse();
        }

        _logger.LogInformation("Could not retrieve the Access Token from Auth0.");
        return new AccessTokenResponse();
    }
}