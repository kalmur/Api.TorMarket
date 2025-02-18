using Api.TorMarket.Application.Interfaces;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<OrderEntity> Order => Set<OrderEntity>();
    public DbSet<OrderLineEntity> OrderLine => Set<OrderLineEntity>();
    public DbSet<OrderStatusEntity> OrderStatus => Set<OrderStatusEntity>();
    public DbSet<ProductEntity> Product => Set<ProductEntity>();
    public DbSet<ProductCategoryEntity> ProductCategory => Set<ProductCategoryEntity>();
    public DbSet<ProductReviewEntity> ProductReview => Set<ProductReviewEntity>();
    public DbSet<ShoppingCartEntity> ShoppingCart => Set<ShoppingCartEntity>();
    public DbSet<ShoppingCartItemEntity> ShoppingCartItem => Set<ShoppingCartItemEntity>();
    public DbSet<SiteUserEntity> SiteUser => Set<SiteUserEntity>();
    public DbSet<UserAddressEntity> UserAddress => Set<UserAddressEntity>();

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
