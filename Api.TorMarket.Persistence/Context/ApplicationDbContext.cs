using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Context;

public class ApplicationDbContext(DbContextOptions options)
    : DbContext(options), IApplicationDbContext
{
    public virtual DbSet<Address> Address => Set<Address>();
    public DbSet<Order> Order => Set<Order>();
    public DbSet<OrderLine> OrderLine => Set<OrderLine>();
    public DbSet<OrderStatus> OrderStatus => Set<OrderStatus>();
    public DbSet<Product> Product => Set<Product>();
    public DbSet<ProductCategory> ProductCategory => Set<ProductCategory>();
    public DbSet<SiteUser> SiteUser => Set<SiteUser>();
    public DbSet<UserAddress> UserAddress => Set<UserAddress>();
    public DbSet<UserProductReview> UserProductReview => Set<UserProductReview>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>()
                     .Where(q => 
                         q.State is EntityState.Added or 
                                    EntityState.Modified
                     ))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = DateTimeOffset.UtcNow;
            }

            entry.Entity.UpdatedOn = DateTimeOffset.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        DataSeed.SeedData(modelBuilder);
    }
}
