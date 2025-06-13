using Api.TorMarket.Persistence.Tests.Extensions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Shouldly;

namespace Api.TorMarket.Persistence.Tests.Repositories.UserRepositoryTests.Methods;

[TestFixture]
internal class CreateAsyncTests : UserRepositoryTestsBase
{
    [Test]
    public async Task CreateAsync_ValidRequest_ReturnsUser()
    {
        // Arrange
        var request = GenerateCreateUserRequest();

        // Act
        var result = await _userRepository.CreateAsync(
            request, 
            _cancellationToken
        );

        // Assert
        result.ShouldSatisfyCreateUserRequest(request);
    }

    [Test]
    public async Task CreateAsync_InvalidRoleId_ThrowsException()
    {
        // Arrange
        var request = GenerateCreateUserRequest();

        request.RoleId = 1337;

        // Act + Assert
        await Should.ThrowAsync<DbUpdateException>(
            async () => await _userRepository.CreateAsync(
                request,
                _cancellationToken
            )
        );
    }

    [Test]
    public async Task CreateAsync_NullProviderId_ThrowsException()
    {
        // Arrange
        var request = GenerateCreateUserRequest();

        request.ProviderId = null;

        // Act + Assert
        await Should.ThrowAsync<DbUpdateException>(
            async () => await _userRepository.CreateAsync(
                request,
                _cancellationToken
            )
        );
    }
}
