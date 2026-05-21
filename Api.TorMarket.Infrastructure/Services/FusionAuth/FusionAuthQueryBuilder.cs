using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Api.TorMarket.Infrastructure.Services.FusionAuth;

public class FusionAuthQueryBuilder : IFusionAuthQueryBuilder
{
    private readonly FusionAuthConfig _options;

    public FusionAuthQueryBuilder(IOptions<FusionAuthConfig> options)
    {
        _options = options.Value;
    }

    public string GenerateQueryString(IReadOnlyCollection<string> providerIds)
    {
        var query = GetUserProfileQueryChunk(providerIds);

        return _options!.UsersQuery!
            .Replace("{FieldsToInclude}", _options.FieldsToInclude)
            .Replace("{IncludeFields}", _options.IncludeFields)
            .Replace("{Query}", query);
    }

    private static string GetUserProfileQueryChunk(IEnumerable<string> providerIds)
        => "id:(\"" + string.Join("\"OR\"", providerIds) + "\")";
}
