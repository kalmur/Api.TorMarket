namespace Api.TorMarket.Application.Abstractions.IdentityProvider;

public interface IFusionAuthQueryBuilder
{
    string GenerateQueryString(IReadOnlyCollection<string> providerIds);
}
