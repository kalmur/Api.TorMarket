using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Tests.CQRS.Commands.CreateUser;
using Api.TorMarket.Domain.Models;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using static Api.TorMarket.Application.CQRS.Commands.Users.CreateUser.CreateUserFailure;

#nullable disable
namespace Api.TorMarket.Application.Tests.CQRS.Commands.Users.CreateUser;

[TestFixture]
internal sealed class CreateUserValidatorTests
{
    private IUserRepository _userRepository;
    private CreateUserValidator _validator;

    [SetUp]
    public void Setup()
    {
        _userRepository = Substitute.For<IUserRepository>();

        _validator = new CreateUserValidator(
            _userRepository
        );
    }

    [Test]
    public async Task ValidateAsync_WhenCommandIsValid_ReturnsNoErrors()
    {
        // Arrange
        var command = CreateUserCommandGenerator.GenerateCommand("auth|007");

        _userRepository.GetByProviderIdAsync(
            command.ProviderId,
            Arg.Any<CancellationToken>()
        ).Returns(
            (User)null
        );

        // Act
        var result = await _validator.ValidateAsync(
            command,
            CancellationToken.None
        );

        // Assert
        result.ShouldBeNull();
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public async Task ValidateAsync_WhenProviderIdIsNullOrEmpty_ReturnsInvalidProviderIdError(
        string providerId
    )
    {
        // Arrange
        var command = CreateUserCommandGenerator.GenerateCommand(providerId);

        // Act
        var result = await _validator.ValidateAsync(
            command,
            CancellationToken.None
        );

        // Assert
        result.ShouldNotBeNull();
        result.Errors.ShouldContain(ErrorType.InvalidProviderId);
    }

    [Test]
    public async Task ValidateAsync_WhenUserAlreadyExists_ReturnsUserAlreadyExistsError()
    {
        // Arrange
        var command = CreateUserCommandGenerator.GenerateCommand("auth|007");

        _userRepository.GetByProviderIdAsync(
            command.ProviderId,
            Arg.Any<CancellationToken>()
        ).Returns(
            new User
            {
                UserId = 1,
                ProviderId = command.ProviderId
            }
        );

        // Act
        var result = await _validator.ValidateAsync(
            command,
            CancellationToken.None
        );

        // Assert
        result.ShouldNotBeNull();
        result.Errors.ShouldContain(ErrorType.UserAlreadyExists);
    }
}
