using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class UserAddressEntityConfiguration : EntityConfigurationBase<UserAddressEntity>
{
    protected override string TableName => TableNames.UserAddresses;

    protected override void ConfigureColumns(EntityTypeBuilder<UserAddressEntity> builder)
    {
        builder
            .Property(a => a.UserAddressId)
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
            .HasMaxLength(UserAddressEntity.UserAddressEntity_CityMaxLength)
            .IsUnicode(false);

        builder
            .Property(a => a.PostalCode)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(UserAddressEntity.UserAddressEntity_PostalCodeMaxLength)
            .IsUnicode(false);

        builder
            .Property(a => a.Country)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(UserAddressEntity.UserAddressEntity_CountryMaxLength)
            .IsUnicode(false);

        builder
            .Property(ua => ua.IsDefault)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<UserAddressEntity> builder)
    {
        builder
            .HasKey(userAddress => userAddress.UserAddressId);

        builder
            .HasOne(userAddress => userAddress.User)
            .WithMany(user => user.Addresses)
            .HasForeignKey(user => user.UserId)
            .HasPrincipalKey(userAddress => userAddress.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<UserAddressEntity> builder)
    {
    }
}
