using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.TorMarket.Persistence.Entities.Configuration.Common;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class OrderEntityConfiguration : EntityConfigurationBase<OrderEntity>
{
    protected override string TableName => TableNames.Orders;

    protected override void ConfigureColumns(EntityTypeBuilder<OrderEntity> builder)
    {
        builder
            .Property(order => order.OrderId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(order => order.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(order => order.StatusId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(order => order.TotalPrice)
            .HasColumnOrder(ColumnOrder++)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(order => order.OrderDate)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<OrderEntity> builder)
    {
        builder
            .HasKey(order => order.OrderId);

        builder
            .HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(user => user.OrderId)
            .HasPrincipalKey(order => order.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(order => order.OrderStatus)
            .WithMany(status => status.Orders)
            .HasForeignKey(status => status.OrderId)
            .HasPrincipalKey(order => order.OrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        // TODO - Confirm
        builder
            .HasOne(order => order.UserAddress)
            .WithMany()
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(order => order.OrderLines)
            .WithOne(orderLine => orderLine.Order)
            .HasForeignKey(orderLine => orderLine.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderEntity> builder)
    {
        builder
            .HasIndex(o => o.UserId);
    }
}