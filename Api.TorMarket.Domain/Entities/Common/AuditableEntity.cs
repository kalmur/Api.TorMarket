namespace Api.TorMarket.Domain.Entities.Common;

public class AuditableEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
