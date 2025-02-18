using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class OrderStatusEntityConfiguration : EntityConfigurationBase<OrderStatusEntity>
{
    protected override string TableName => TableNames.OrderStatus;

    protected override void ConfigureColumns(EntityTypeBuilder<OrderStatusEntity> builder)
    {
        builder
            .Property(os => os.Id)
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
            .HasKey(os => os.Id);

        builder
            .HasMany(os => os.Orders)
            .WithOne(o => o.StatusEntity)
            .HasForeignKey(o => o.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<OrderStatusEntity> builder)
    {
    }
}
