using Api.TorMarket.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<OrderEntity> Order { get; }
    DbSet<OrderLineEntity> OrderLine { get; }
    DbSet<OrderStatusEntity> OrderStatus { get; }
    DbSet<ListingEntity> Listing { get; }
    DbSet<ListingCategoryEntity> ListingCategory { get; }
    DbSet<ListingReviewEntity> ListingReview { get; }
    DbSet<ShoppingCartEntity> ShoppingCart { get; }
    DbSet<ShoppingCartItemEntity> ShoppingCartItem { get; }
    DbSet<UserEntity> User { get; }
    DbSet<UserAddressEntity> UserAddress { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
