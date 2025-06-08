using Api.TorMarket.Domain.Models.External;
using Auth0.AuthenticationApi.Models;

namespace Api.TorMarket.Application.Abstractions;

public interface IIdentityProviderService
{
    Task<IReadOnlyCollection<Auth0User>> GetUsersInformationAsync(IReadOnlyCollection<string> externalProviderIds, CancellationToken token = default);
    Task<AccessTokenResponse> RetrieveAccessTokenAsync(CancellationToken token = default);
}
