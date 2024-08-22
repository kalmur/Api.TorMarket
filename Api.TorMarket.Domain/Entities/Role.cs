namespace Api.TorMarket.Domain.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual IReadOnlyCollection<User> Users { get; set; }
}
