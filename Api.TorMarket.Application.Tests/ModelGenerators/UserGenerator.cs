using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Tests.ModelGenerators;

internal static class UserGenerator
{
    internal static User GenerateUser(
        int userId = 1
    ) => new()
    {
        UserId = userId,
        ProviderId = "auth|007"
    };
}
