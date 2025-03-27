using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.TorMarket.Persistence.Entities.Configuration.Common;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal class OrderEntityConfiguration : EntityConfigurationBase<OrderEntity>
{
    protected override string TableName => TableNames.Orders;

    protected override void ConfigureColumns(EntityTypeBuilder<OrderEntity> builder)
    {
        builder
            .Property(o => o.OrderId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(o => o.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(o => o.OrderStatus)
            .IsRequired();

        builder
            .Property(o => o.ShippingAddress)
            .IsRequired();

        builder
            .Property(o => o.TotalPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(o => o.OrderDate)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<OrderEntity> builder)
    {
        builder
            .HasKey(o => o.OrderId);

        builder
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(o => o.StatusEntity)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Address)
            .WithMany()
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(o => o.OrderLines)
            .WithOne(o => o.Order)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderEntity> builder)
    {
        builder
            .HasIndex(o => o.UserId);
    }
}