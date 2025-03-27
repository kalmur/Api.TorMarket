using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.TorMarket.Persistence.Entities.Configuration.Common;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal class OrderStatusEntityConfiguration : EntityConfigurationBase<OrderStatusEntity>
{
    protected override string TableName => TableNames.OrderStatuses;

    protected override void ConfigureColumns(EntityTypeBuilder<OrderStatusEntity> builder)
    {
        builder
            .Property(os => os.OrderStatusId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(os => os.Status)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(50);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<OrderStatusEntity> builder)
    {
        builder
            .HasKey(os => os.OrderStatusId);

        builder
            .HasMany(os => os.Orders)
            .WithOne(o => o.StatusEntity)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderStatusEntity> builder)
    {
    }
}
