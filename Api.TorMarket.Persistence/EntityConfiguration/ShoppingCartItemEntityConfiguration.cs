using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class ShoppingCartItemEntityConfiguration : EntityConfigurationBase<ShoppingCartItemEntity>
{
    protected override string TableName => TableNames.ShoppingCartItem;

    protected override void ConfigureColumns(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
        builder
            .Property(sci => sci.ShoppingCartItemId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(sci => sci.CartId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(sci => sci.ProductId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(sci => sci.Quantity)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
        builder
            .HasKey(sci => sci.ShoppingCartItemId);

        builder
            .HasOne(sci => sci.ShoppingCart)
            .WithMany(sc => sc.Items)
            .HasForeignKey(sci => sci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(sci => sci.Product)
            .WithMany(p => p.ShoppingCartItems)
            .HasForeignKey(sci => sci.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
    }
}