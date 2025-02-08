using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class UserAddressEntityConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder
            .ToTable(TableNames.UserAddress);

        builder
            .Property(ua => ua.UserId)
            .IsRequired();

        builder
            .Property(ua => ua.AddressId)
            .IsRequired();

        // Navigation
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserAddresses)
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.Address)
            .WithMany(x => x.UserAddresses)
            .HasForeignKey(x => x.AddressId);
    }
}
