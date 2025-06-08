using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Api.TorMarket.Infrastructure.Services.Auth0;

public class Auth0QueryBuilder : IAuth0QueryBuilder
{
    private readonly Auth0Config _options;

    public Auth0QueryBuilder(IOptions<Auth0Config> options)
    {
        _options = options.Value;
    }

    /// <summary>
    ///     Generates a query string based on ExternalProviderId's
    /// </summary>
    /// <param name="externalProviderIds">The Id's of the Users.</param>
    /// <returns>A string.</returns>
    public string GenerateQueryString(IReadOnlyCollection<string> externalProviderIds)
    {
        var query = GetUserProfileQueryChunk(externalProviderIds);

        return _options!.UsersQuery!
            .Replace("{FieldsToInclude}", _options.FieldsToInclude)
            .Replace("{IncludeFields}", _options.IncludeFields)
            .Replace("{Query}", query)
            .Replace("{SearchEngine}", _options.SearchEngine);
    }

    private static string GetUserProfileQueryChunk(IEnumerable<string> externalProviderIds)
        => "user_id:(\"" + string.Join("\"OR\"", externalProviderIds) + "\")";
}
