using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Persistence.SeedData;

public static class RoleData
{
    public static readonly List<Role> Roles =
    [
        new Role { RoleId = 1, Name = "Admin", Description = "Administrator" },
        new Role { RoleId = 2, Name = "User", Description = "Tor Market User" }
    ];
}
