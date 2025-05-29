using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class ShoppingCartEntityConfiguration : EntityConfigurationBase<ShoppingCartEntity>
{
    protected override string TableName => TableNames.ShoppingCarts;

    protected override void ConfigureColumns(EntityTypeBuilder<ShoppingCartEntity> builder)
    {
        builder
            .Property(shoppingCart => shoppingCart.ShoppingCartId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(shoppingCart => shoppingCart.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ShoppingCartEntity> builder)
    {
        builder
            .HasKey(shoppingCart => shoppingCart.ShoppingCartId);

        builder
            .HasOne(shoppingCart => shoppingCart.User)
            .WithMany(user => user.ShoppingCarts)
            .HasForeignKey(user => user.UserId)
            .HasPrincipalKey(shoppingCart => shoppingCart.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ShoppingCartEntity> builder)
    {
        builder
            .HasIndex(pr => pr.UserId);
    }
}
