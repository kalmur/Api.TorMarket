using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class OrderStatusEntityConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder
            .ToTable(TableNames.OrderStatus)
            .HasKey(os => os.Id);

        builder
            .Property(os => os.Status)
            .IsRequired()
            .HasMaxLength(50);

        // Navigation
        builder
            .HasMany(os => os.Orders)
            .WithOne(o => o.Status)
            .HasForeignKey(o => o.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
