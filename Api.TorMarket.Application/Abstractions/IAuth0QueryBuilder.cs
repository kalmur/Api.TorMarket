namespace Api.TorMarket.Application.Abstractions;

public interface IAuth0QueryBuilder
{
    string GenerateQueryString(IReadOnlyCollection<string> externalProviderIds);
}
