using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class OrderLineEntityConfiguration : EntityConfigurationBase<OrderLineEntity>
{
    protected override string TableName => TableNames.OrderLines;

    protected override void ConfigureColumns(EntityTypeBuilder<OrderLineEntity> builder)
    {
        builder
            .Property(orderLine => orderLine.OrderLineId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(orderLine => orderLine.ListingId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(orderLine => orderLine.OrderId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(orderLine => orderLine.Quantity)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(orderLine => orderLine.Price)
            .HasColumnOrder(ColumnOrder++)
            .HasColumnType(OrderLine.Price_ColumnType)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<OrderLineEntity> builder)
    {
        builder
            .HasKey(orderLine => orderLine.OrderLineId);

        builder
            .HasOne(orderLine => orderLine.Listing)
            .WithMany(listing => listing.OrderLines)
            .HasForeignKey(orderLine => orderLine.OrderLineId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(orderLine => orderLine.Order)
            .WithMany(order => order.OrderLines)
            .HasForeignKey(orderLine => orderLine.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderLineEntity> builder)
    {
    }
}