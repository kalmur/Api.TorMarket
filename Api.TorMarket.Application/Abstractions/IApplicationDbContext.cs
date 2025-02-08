using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Address> Address { get; }
    DbSet<Order> Order { get; }
    DbSet<OrderLine> OrderLine { get; }
    DbSet<OrderStatus> OrderStatus { get; }
    DbSet<Product> Product { get; }
    DbSet<ProductCategory> ProductCategory { get; }
    DbSet<SiteUser> SiteUser { get; }
    DbSet<UserAddress> UserAddress { get; }
    DbSet<UserProductReview> UserProductReview { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
