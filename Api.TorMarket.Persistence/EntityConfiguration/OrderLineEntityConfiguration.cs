using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class OrderLineEntityConfiguration : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder
            .ToTable(TableNames.OrderLine)
            .HasKey(ol => ol.Id);

        builder
            .Property(ol => ol.ProductId)
            .IsRequired();

        builder
            .Property(ol => ol.OrderId)
            .IsRequired();

        builder
            .Property(ol => ol.Quantity)
            .IsRequired();

        builder
            .Property(ol => ol.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        // Navigation
        builder.HasOne(ol => ol.Product)
            .WithMany()
            .HasForeignKey(ol => ol.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ol => ol.Order)
            .WithMany()
            .HasForeignKey(ol => ol.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}