using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal class UserEntityConfiguration : EntityConfigurationBase<UserEntity>
{
    protected override string TableName => TableNames.Users;

    protected override void ConfigureColumns(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .Property(x => x.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.ProviderId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(x => x.CreatedOn)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(x => x.UpdatedOn)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .ToTable(TableNames.Users)
            .HasKey(x => x.UserId);

        builder
            .HasMany(u => u.Listings)
            .WithOne(p => p.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.ListingReviews)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.Addresses)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasIndex(su => su.ProviderId)
            .IsUnique();
    }
}
