namespace Api.TorMarket.Domain.Entities.Common;

public class AuditableEntity
{
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}
