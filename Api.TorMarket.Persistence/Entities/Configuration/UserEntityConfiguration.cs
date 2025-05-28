using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class UserEntityConfiguration : EntityConfigurationBase<UserEntity>
{
    protected override string TableName => TableNames.Users;

    protected override void ConfigureColumns(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .Property(user => user.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(user => user.ProviderId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(User.ProviderId_MaxLength);

        builder
            .Property(user => user.CreatedDate)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(user => user.UpdatedDate)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasKey(user => user.UserId);

        builder
            .HasMany(user => user.Listings)
            .WithOne(listing => listing.User)
            .HasForeignKey(listing => listing.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(user => user.ListingReviews)
            .WithOne(listingReviews => listingReviews.User)
            .HasForeignKey(listingReviews => listingReviews.UserId)
            .HasPrincipalKey(user => user.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(user => user.Addresses)
            .WithOne(address => address.User)
            .HasForeignKey(address => address.UserId)
            .HasPrincipalKey(user => user.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasIndex(user => user.ProviderId)
            .IsUnique();
    }
}
