using Api.TorMarket.Application.Abstractions.IdentityProvider;
using Api.TorMarket.Application.CQRS.Commands.Users.CreateUser;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.Domain.Models.External;
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
    private IIdentityProviderService _identityProviderService;
    private CreateUserValidator _validator;

    [SetUp]
    public void Setup()
    {
        _userRepository = Substitute.For<IUserRepository>();
        _identityProviderService = Substitute.For<IIdentityProviderService>();

        _validator = new CreateUserValidator(
            _userRepository,
            _identityProviderService
        );
    }

    [Test]
    public async Task ValidateAsync_WhenCommandIsValid_ReturnsNoErrors()
    {
        // Arrange
        var command = CreateUserCommandGenerator.GenerateCommand(
            roleId: 1,
            providerId: "auth|007"
        );

        _userRepository.GetByProviderIdAsync(
            command.ProviderId,
            Arg.Any<CancellationToken>()
        ).Returns(
            (User)null
        );

        _identityProviderService.GetUsersInformationAsync(
            Arg.Any<IReadOnlyCollection<string>>(),
            Arg.Any<CancellationToken>()
        ).Returns(
            new List<FusionAuthUser>
            {
                new() { ExternalProviderId = command.ProviderId }
            }
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
        var command = CreateUserCommandGenerator.GenerateCommand(
            roleId: 1,
            providerId
        );

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
        var command = CreateUserCommandGenerator.GenerateCommand(
            roleId: 1,
            providerId: "auth|007"
        );

        _userRepository.GetByProviderIdAsync(
            command.ProviderId,
            Arg.Any<CancellationToken>()
        ).Returns(
            new User
            {
                UserId = 1,
                RoleId = 1,
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
