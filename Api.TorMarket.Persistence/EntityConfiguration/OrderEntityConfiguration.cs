using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .ToTable(TableNames.Order)
            .HasKey(o => o.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(o => o.UserId)
            .IsRequired();

        builder
            .Property(o => o.OrderStatus)
            .IsRequired();

        builder
            .Property(o => o.ShippingAddress)
            .IsRequired();

        builder
            .Property(o => o.TotalPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(o => o.OrderDate)
            .IsRequired();

        // Navigation
        builder
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey(o => o.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(o => o.Status)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Address)
            .WithMany()
            .HasForeignKey(o => o.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}