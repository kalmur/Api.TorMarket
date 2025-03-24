namespace Api.TorMarket.Persistence.Entities;

internal class AuditableEntity
{
    internal DateTimeOffset CreatedOn { get; set; }
    internal DateTimeOffset UpdatedOn { get; set; }
}
