namespace Api.TorMarket.Persistence.Entities;

internal class AuditableEntity
{
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}
