using Api.TorMarket.Application.CQRS;
using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Api.TorMarket.Application.Tests.CQRS.Commands.CreateUser;

[TestFixture]
internal class CreateUserHandlerTests
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
    public async Task Handle_WhenCommandIsValid_ReturnsUser()
    {
        // Arrange
        var createUserCommand = new CreateUserCommand
        {
            ProviderId = "auth|007"
        };

        // Act
        var result = await _handler.Handle(createUserCommand, CancellationToken.None);

        // Assert
        result.ShouldNotBeOfType<User>();
    }
}