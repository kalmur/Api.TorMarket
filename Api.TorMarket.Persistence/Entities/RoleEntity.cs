namespace Api.TorMarket.Persistence.Entities;

internal class RoleEntity
{
    internal int RoleId { get; set; }
    internal required string Name { get; set; }

    internal virtual ICollection<UserEntity> Users { get; set; } = null!;
}
