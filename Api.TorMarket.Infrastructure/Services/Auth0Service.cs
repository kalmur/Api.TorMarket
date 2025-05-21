using Api.TorMarket.Application.Abstractions;
using Microsoft.Extensions.Options;
using Api.TorMarket.Infrastructure.Options;

namespace Api.TorMarket.Infrastructure.Services;

internal sealed class Auth0Service : IAuth0Service
{
    private const string ProviderName = "Auth0";

    private readonly IAuth0UsersClient _usersClient;
    private readonly Auth0Config _options;

    public Auth0Service
    (
        IAuth0UsersClient usersClient,
        IOptions<Auth0Config> options
    )
    {
        _usersClient = usersClient;
        _options = options.Value;
    }
}
