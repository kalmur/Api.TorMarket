using Api.TorMarket.Application.Abstractions.IdentityProvider;
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

    public string GenerateQueryString(IReadOnlyCollection<string> providerIds)
    {
        var query = GetUserProfileQueryChunk(providerIds);

        return _options!.UsersQuery!
            .Replace("{FieldsToInclude}", _options.FieldsToInclude)
            .Replace("{IncludeFields}", _options.IncludeFields)
            .Replace("{Query}", query)
            .Replace("{SearchEngine}", _options.SearchEngine);
    }

    private static string GetUserProfileQueryChunk(IEnumerable<string> providerIds)
        => "user_id:(\"" + string.Join("\"OR\"", providerIds) + "\")";
}