using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class ShoppingCartEntityConfiguration : EntityConfigurationBase<ShoppingCartEntity>
{
    protected override string TableName => TableNames.ShoppingCart;

    protected override void ConfigureColumns(EntityTypeBuilder<ShoppingCartEntity> builder)
    {
        builder
            .Property(sc => sc.ShoppingCartId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(sc => sc.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ShoppingCartEntity> builder)
    {
        builder
            .HasKey(sc => sc.ShoppingCartId);

        builder
            .HasOne(sc => sc.User)
            .WithMany(u => u.ShoppingCarts)
            .HasForeignKey(sc => sc.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ShoppingCartEntity> builder)
    {
        builder
            .HasIndex(pr => pr.UserId);
    }
}
