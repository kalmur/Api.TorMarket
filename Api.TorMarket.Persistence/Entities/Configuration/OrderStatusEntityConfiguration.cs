using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Api.TorMarket.Domain.Models;

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
            .HasMaxLength(OrderStatus.Status_MaxLength);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<OrderStatusEntity> builder)
    {
        builder
            .HasKey(orderStatus => orderStatus.OrderStatusId);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderStatusEntity> builder)
    {
    }
}
