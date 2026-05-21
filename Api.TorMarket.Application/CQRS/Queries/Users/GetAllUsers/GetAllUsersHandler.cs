using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetAllUsers;

public sealed class GetAllUsersHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<UserProfile>>
{
    private readonly IUserRepository _userRepository;
    private readonly IIdentityProviderService _identityProviderService;

    public GetAllUsersHandler(
        IUserRepository userRepository,
        IIdentityProviderService identityProviderService
    )
    {
        _userRepository = userRepository;
        _identityProviderService = identityProviderService;
    }

    public async Task<IEnumerable<UserProfile>> HandleAsync(
        GetAllUsersQuery request,
        CancellationToken cancellationToken
    )
    {
        var users = (await _userRepository.GetAllAsync(cancellationToken))
            .Where(u => u is not null)
            .Select(u => u!)
            .ToList();

        if (users.Count == 0)
        {
            return Enumerable.Empty<UserProfile>();
        }

        var providerIds = users.Select(u => u.ProviderId).ToList();

        var identityProfiles = await _identityProviderService.GetUsersInformationAsync(
            providerIds,
            cancellationToken
        );

        var profileLookup = identityProfiles
            .Where(p => !string.IsNullOrEmpty(p.ExternalProviderId))
            .ToDictionary(p => p.ExternalProviderId!, StringComparer.Ordinal);

        return users.Select(user => new UserProfile
        {
            User = user,
            IdentityProfile = profileLookup.TryGetValue(user.ProviderId, out var profile)
                ? profile
                : null
        });
    }
}