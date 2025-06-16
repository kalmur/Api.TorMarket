using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Domain.Models;
using Shouldly;

namespace Api.TorMarket.Persistence.Tests.Extensions;

internal static class UserExtensions
{
    public static void ShouldSatisfyCreateUserRequest(
        this User createdUser,
        CreateUserRequest request
    ) => createdUser.ShouldSatisfyAllConditions(
        user => user.RoleId.ShouldBe(request.RoleId),
        user => user.ProviderId.ShouldBe(request.ProviderId)
    );
}
