using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

namespace Api.TorMarket.Application.Tests.CQRS.Commands.Users.CreateUser;

internal sealed class CreateUserCommandGenerator
{
    public static CreateUserCommand GenerateCommand(
        int roleId,
        string providerId
    ) => new()
    {
        RoleId = roleId,
        ProviderId = providerId
    };
}
