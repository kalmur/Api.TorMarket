namespace Api.TorMarket.Persistence.Entities;

public class AuditableEntity
{
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}
