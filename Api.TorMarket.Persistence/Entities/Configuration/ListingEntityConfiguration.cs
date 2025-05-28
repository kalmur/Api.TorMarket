using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class ListingEntityConfiguration : EntityConfigurationBase<ListingEntity>
{
    protected override string TableName => TableNames.Listings;

    protected override void ConfigureColumns(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .Property(listing => listing.ListingId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(listing => listing.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listing => listing.CategoryId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listing => listing.Name)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listing => listing.Price)
            .HasColumnOrder(ColumnOrder++)
            .HasColumnType("decimal(18,2)");

        builder
            .Property(listing => listing.Description)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .HasKey(listing => listing.ListingId);

        builder
            .HasOne(listing => listing.User)
            .WithMany(u => u.Listings)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.ListingCategory)
            .WithMany(x => x.Listings)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.UserProductReviews)
            .WithOne(x => x.Listing)
            .HasForeignKey(x => x.ListingId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .HasIndex(pr => pr.UserId);

        builder
            .HasIndex(pr => pr.CategoryId);
    }
}
