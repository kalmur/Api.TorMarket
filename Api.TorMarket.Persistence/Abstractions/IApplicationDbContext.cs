using Api.TorMarket.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Abstractions;

internal interface IApplicationDbContext
{
    DbSet<CategoryEntity> Category { get; }
    DbSet<CurrencyEntity> Currency { get; }
    DbSet<ListingEntity> Listing { get; }
    DbSet<ListingBlobEntity> ListingBlob { get; }
    DbSet<ListingReviewEntity> ListingReview { get; }
    DbSet<RoleEntity> Role { get; }
    DbSet<OrderEntity> Order { get; }
    DbSet<OrderLineEntity> OrderLine { get; }
    DbSet<OrderStatusEntity> OrderStatus { get; }
    DbSet<ShoppingCartEntity> ShoppingCart { get; }
    DbSet<ShoppingCartItemEntity> ShoppingCartItem { get; }
    DbSet<UserEntity> User { get; }
    DbSet<UserAddressEntity> UserAddress { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    );
}
