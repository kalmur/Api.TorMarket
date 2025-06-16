using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Persistence.Repositories;
using NUnit.Framework;

namespace Api.TorMarket.Persistence.Tests.Repositories.UserRepositoryTests;

internal class UserRepositoryTestsBase : RepositoryTestsBase
{
    protected IUserRepository _userRepository; 

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _userRepository = new UserRepository(
            _dbContext
        );
    }

    protected CreateUserRequest GenerateCreateUserRequest()
        => new()
        {
            RoleId = GenerateNextRoleId(),
            ProviderId = GenerateNextProviderId()
        };
}
