using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.TorMarket.Persistence.Entities.Configuration.Common;

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
            .Property(orderLine => orderLine.ProductId)
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
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<OrderLineEntity> builder)
    {
        builder
            .HasKey(orderLine => orderLine.OrderLineId);

        builder
            .HasOne(orderLine => orderLine.Listing)
            .WithMany(listing => listing.OrderLines)
            .HasForeignKey(listing => listing.OrderLineId)
            .HasPrincipalKey(orderLine => orderLine.ListingId)
            .OnDelete(DeleteBehavior.Cascade);

        // TODO - Check this constraint
        builder
            .HasOne(orderLine => orderLine.Order)
            .WithMany(order => order.OrderLines)
            .HasForeignKey(orderLine => orderLine.OrderLineId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderLineEntity> builder)
    {
    }
}