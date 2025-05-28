using Api.TorMarket.Persistence.Abstractions;
using Api.TorMarket.Persistence.Entities;
using Api.TorMarket.Persistence.Entities.Common;
using Microsoft.EntityFrameworkCore;
using ListingCategoryEntity = Api.TorMarket.Persistence.Entities.ListingCategoryEntity;
using ListingEntity = Api.TorMarket.Persistence.Entities.ListingEntity;
using ListingReviewEntity = Api.TorMarket.Persistence.Entities.ListingReviewEntity;
using OrderEntity = Api.TorMarket.Persistence.Entities.OrderEntity;
using OrderLineEntity = Api.TorMarket.Persistence.Entities.OrderLineEntity;
using OrderStatusEntity = Api.TorMarket.Persistence.Entities.OrderStatusEntity;
using ShoppingCartEntity = Api.TorMarket.Persistence.Entities.ShoppingCartEntity;
using ShoppingCartItemEntity = Api.TorMarket.Persistence.Entities.ShoppingCartItemEntity;
using UserAddressEntity = Api.TorMarket.Persistence.Entities.UserAddressEntity;
using UserEntity = Api.TorMarket.Persistence.Entities.UserEntity;

namespace Api.TorMarket.Persistence.Context;

internal sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<OrderEntity> Order => Set<OrderEntity>();
    public DbSet<OrderLineEntity> OrderLine => Set<OrderLineEntity>();
    public DbSet<OrderStatusEntity> OrderStatus => Set<OrderStatusEntity>();
    public DbSet<ListingEntity> Listing => Set<ListingEntity>();
    public DbSet<ListingBlobEntity> ListingBlob => Set<ListingBlobEntity>();
    public DbSet<ListingCategoryEntity> ListingCategory => Set<ListingCategoryEntity>();
    public DbSet<ListingReviewEntity> ListingReview => Set<ListingReviewEntity>();
    public DbSet<ShoppingCartEntity> ShoppingCart => Set<ShoppingCartEntity>();
    public DbSet<ShoppingCartItemEntity> ShoppingCartItem => Set<ShoppingCartItemEntity>();
    public DbSet<UserEntity> User => Set<UserEntity>();
    public DbSet<UserAddressEntity> UserAddress => Set<UserAddressEntity>();


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>()
                     .Where(
                            q => q.State is EntityState.Added or 
                                            EntityState.Modified
                        )
                     )
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
            }

            entry.Entity.UpdatedDate = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        DataSeed.SeedData(modelBuilder);
    }
}
