using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class ShoppingCartItemEntityConfiguration : EntityConfigurationBase<ShoppingCartItemEntity>
{
    protected override string TableName => TableNames.ShoppingCartItems;

    protected override void ConfigureColumns(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
        builder
            .Property(shoppingCartItem => shoppingCartItem.ShoppingCartItemId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(shoppingCartItem => shoppingCartItem.CartId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(shoppingCartItem => shoppingCartItem.ProductId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(shoppingCartItem => shoppingCartItem.Quantity)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
        builder
            .HasKey(shoppingCartItem => shoppingCartItem.ShoppingCartItemId);

        builder
            .HasOne(shoppingCartItem => shoppingCartItem.ShoppingCart)
            .WithMany(shoppingCart => shoppingCart.Items)
            .HasForeignKey(shoppingCart => shoppingCart.CartId)
            .HasPrincipalKey(shoppingCartItem => shoppingCartItem.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);

        // TODO - Check constraint
        builder
            .HasOne(shoppingCart => shoppingCart.Listing)
            .WithMany(listing => listing.ShoppingCartItems)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
    }
}