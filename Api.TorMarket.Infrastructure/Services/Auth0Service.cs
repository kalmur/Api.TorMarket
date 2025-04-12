using Microsoft.Extensions.Options;
using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Infrastructure.Services.Interfaces;

namespace Api.TorMarket.Infrastructure.Services;

internal class Auth0Service : IAuth0Service
{
    private const string ProviderName = "Auth0";

    private readonly IAuth0UsersClient _usersClient;
    private readonly Auth0Settings _options;

    public Auth0Service
    (
        IAuth0UsersClient usersClient,
        IOptions<Auth0Settings> options
    )
    {
        _usersClient = usersClient;
        _options = options.Value;
    }
}
