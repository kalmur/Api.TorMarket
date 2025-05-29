using Api.TorMarket.Application.CQRS;
using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using static Api.TorMarket.Application.CQRS.Commands.Users.CreateUser.CreateUserFailure;

#nullable disable
namespace Api.TorMarket.Application.Tests.CQRS.Commands.Users.CreateUser;

[TestFixture]
internal sealed class CreateUserHandlerTests
{
    private IUserRepository _userRepository;
    private IValidator<CreateUserCommand, CreateUserFailure> _validator;

    private CreateUserHandler _handler;

    [SetUp]
    public void Setup()
    {
        _validator = Substitute.For<IValidator<CreateUserCommand, CreateUserFailure>>();
        _userRepository = Substitute.For<IUserRepository>();

        _handler = new CreateUserHandler(
            _validator,
            _userRepository
        );
    }

    [Test]
    public async Task Handle_WhenValidationPasses_ReturnsUser()
    {
        // Arrange
        var command = CreateUserCommandGenerator.GenerateCommand(
            roleId: 1, 
            providerId: "auth|007"
        );

        var expectedResult = new User
        {
            UserId = 1,
            RoleId = 1,
            ProviderId = command.ProviderId
        };

        _validator.SetupToPassValidation();

        _userRepository.CreateUserAsync(
            Arg.Any<CreateUserRequest>(),
            Arg.Any<CancellationToken>()
        ).Returns(expectedResult);

        // Act
        var result = await _handler.Handle(
            command,
            CancellationToken.None
        );

        // Assert
        result.IsResult.ShouldBeTrue();
        result.Result.ShouldNotBeNull();
        result.Result.ShouldBe(expectedResult);
    }

    [Test]
    public async Task Handle_WhenValidationFails_ReturnsFailure()
    {
        // Arrange
        var command = CreateUserCommandGenerator.GenerateCommand(
            roleId: 1,
            providerId: ""
        );

        _validator.SetupToFailValidation(ErrorType.InvalidProviderId);

        // Act
        var result = await _handler.Handle(
            command,
            CancellationToken.None
        );

        // Assert
        result.IsError.ShouldBeTrue();
        result.Error.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(ErrorType.InvalidProviderId);

        await _validator.Received(1).ValidateAsync(
            command,
            Arg.Any<CancellationToken>()
        );

        await _userRepository.DidNotReceive().CreateUserAsync(
            Arg.Any<CreateUserRequest>(),
            Arg.Any<CancellationToken>()
        );
    }
}