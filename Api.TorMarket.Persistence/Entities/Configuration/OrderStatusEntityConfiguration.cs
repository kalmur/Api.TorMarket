using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.TorMarket.Persistence.Entities.Configuration.Common;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class OrderStatusEntityConfiguration : EntityConfigurationBase<OrderStatusEntity>
{
    protected override string TableName => TableNames.OrderStatuses;

    protected override void ConfigureColumns(EntityTypeBuilder<OrderStatusEntity> builder)
    {
        builder
            .Property(orderStatus => orderStatus.OrderStatusId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(orderStatus => orderStatus.Status)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(OrderStatusEntity.OrderStatusEntity_StatusMaxLength);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<OrderStatusEntity> builder)
    {
        builder
            .HasKey(orderStatus => orderStatus.OrderStatusId);

        // TODO - Check constraint
        builder
            .HasMany(orderStatus => orderStatus.Orders)
            .WithOne(order => order.OrderStatus)
            .HasForeignKey(order => order.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderStatusEntity> builder)
    {
    }
}
