using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.CQRS;
using NSubstitute;
using static Api.TorMarket.Application.CQRS.Commands.Users.CreateUser.CreateUserFailure;

namespace Api.TorMarket.Application.Tests.CQRS.Commands.CreateUser;

internal static class CreateUserValidatorExtensions
{
    public static void SetupToPassValidation(
        this IValidator<CreateUserCommand, CreateUserFailure> validator
    ) =>
        validator.ValidateAsync(
            Arg.Any<CreateUserCommand>(), 
            Arg.Any<CancellationToken>()
        ).Returns(
            (CreateUserFailure?)null
        );

    public static void SetupToFailValidation(
        this IValidator<CreateUserCommand, CreateUserFailure> validator,
        ErrorType error
    ) =>
        validator.ValidateAsync(
            Arg.Any<CreateUserCommand>(), 
            Arg.Any<CancellationToken>()
        ).Returns(
            new CreateUserFailure
            {
                Errors = [error]
            }
        );
}
