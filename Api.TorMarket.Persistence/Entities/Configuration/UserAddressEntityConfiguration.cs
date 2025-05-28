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
            .Property(userAddress => userAddress.UserAddressId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(userAddress => userAddress.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(userAddress => userAddress.UnitNumber)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(userAddress => userAddress.StreetNumber)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(userAddress => userAddress.AddressLine)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(UserAddressEntity.AddressLine_MaxLength)
            .IsUnicode(false);

        builder
            .Property(userAddress => userAddress.City)
            .HasColumnOrder(ColumnOrder++)
            .HasMaxLength(UserAddressEntity.City_MaxLength)
            .IsUnicode(false);

        builder
            .Property(a => a.PostalCode)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(UserAddressEntity.PostalCode_MaxLength)
            .IsUnicode(false);

        builder
            .Property(a => a.Country)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(UserAddressEntity.Country_MaxLength)
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
