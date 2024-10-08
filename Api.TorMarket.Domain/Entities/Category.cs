﻿using Api.TorMarket.Domain.Entities.Common;

namespace Api.TorMarket.Domain.Entities;

public class Category : AuditableEntity
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    public virtual IReadOnlyCollection<Listing> Listings { get; set; }
}
