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
            .Property(ol => ol.OrderLineId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(ol => ol.ProductId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(ol => ol.OrderId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(ol => ol.Quantity)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(ol => ol.Price)
            .HasColumnOrder(ColumnOrder++)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<OrderLineEntity> builder)
    {
        builder
            .HasKey(ol => ol.OrderLineId);

        builder
            .HasOne(ol => ol.Product)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(ol => ol.OrderLineId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ol => ol.Order)
            .WithMany()
            .HasForeignKey(ol => ol.OrderLineId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderLineEntity> builder)
    {
    }
}