using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;

namespace Api.TorMarket.Application.Tests.CQRS.Commands.CreateUser;

internal sealed class CreateUserCommandGenerator
{
    public static CreateUserCommand GenerateCommand(
        string providerId
    ) => new()
    {
        ProviderId = providerId
    };
}
