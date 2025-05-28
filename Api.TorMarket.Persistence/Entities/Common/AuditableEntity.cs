namespace Api.TorMarket.Persistence.Entities.Common;

internal class AuditableEntity
{
    internal DateTime CreatedDate { get; set; }
    internal DateTime UpdatedDate { get; set; }
}
