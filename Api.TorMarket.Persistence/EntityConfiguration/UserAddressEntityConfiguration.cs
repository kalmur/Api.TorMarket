using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class UserAddressEntityConfiguration : EntityConfigurationBase<UserAddressEntity>
{
    protected override string TableName => TableNames.UserAddress;

    protected override void ConfigureColumns(EntityTypeBuilder<UserAddressEntity> builder)
    {
        builder
            .Property(a => a.Id)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(ua => ua.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(a => a.UnitNumber)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(a => a.StreetNumber)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(a => a.AddressLine)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

        builder
            .Property(a => a.City)
            .HasColumnOrder(ColumnOrder++)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder
            .Property(a => a.PostalCode)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(false);

        builder
            .Property(a => a.Country)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

        builder
            .Property(ua => ua.IsDefault)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<UserAddressEntity> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(ua => ua.User)
            .WithMany(u => u.Addresses)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<UserAddressEntity> builder)
    {
    }
}
