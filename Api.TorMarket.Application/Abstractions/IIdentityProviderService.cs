using Api.TorMarket.Domain.Model.External;
using Api.TorMarket.Domain.Models.External;

namespace Api.TorMarket.Application.Abstractions;

public interface IIdentityProviderService
{
    Task<IReadOnlyCollection<Auth0User>> GetUsersInformationAsync(
        IReadOnlyCollection<string> providerIds, 
        CancellationToken token = default
    );

    Task<AccessTokenResponse> RetrieveAccessTokenAsync(
        CancellationToken token = default
    );
}
