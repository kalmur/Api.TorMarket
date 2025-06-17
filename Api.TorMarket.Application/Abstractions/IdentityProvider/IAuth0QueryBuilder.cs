namespace Api.TorMarket.Application.Abstractions.IdentityProvider;

public interface IAuth0QueryBuilder
{
    string GenerateQueryString(IReadOnlyCollection<string> externalProviderIds);
}
