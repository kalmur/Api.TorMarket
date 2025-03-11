using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<OrderEntity> Order { get; }
    DbSet<OrderLineEntity> OrderLine { get; }
    DbSet<OrderStatusEntity> OrderStatus { get; }
    DbSet<ProductEntity> Product { get; }
    DbSet<ProductCategoryEntity> ProductCategory { get; }
    DbSet<ProductReviewEntity> ProductReview { get; }
    DbSet<ShoppingCartEntity> ShoppingCart { get; }
    DbSet<ShoppingCartItemEntity> ShoppingCartItem { get; }
    DbSet<UserEntity> SiteUser { get; }
    DbSet<UserAddressEntity> UserAddress { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
