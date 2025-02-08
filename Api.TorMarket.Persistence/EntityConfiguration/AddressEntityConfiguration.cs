using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .ToTable(TableNames.Address)
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(a => a.UnitNumber)
            .IsRequired();

        builder
            .Property(a => a.StreetNumber)
            .IsRequired();

        builder
            .Property(a => a.AddressLine)
            .HasMaxLength(100);

        builder
            .Property(a => a.City)
            .HasMaxLength(50);

        builder
            .Property(a => a.PostalCode)
            .HasMaxLength(10);

        builder
            .Property(a => a.Country)
            .HasMaxLength(50);

        // Navigation
        builder
            .HasMany(a => a.UserAddresses)
            .WithOne(ua => ua.Address)
            .HasForeignKey(ua => ua.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
