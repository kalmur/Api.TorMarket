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
            .HasMaxLength(ListingEntity.ListingEntity_NameMaxLength)
            .IsRequired();

        builder
            .Property(listing => listing.Price)
            .HasColumnOrder(ColumnOrder++)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(listing => listing.Description)
            .HasColumnOrder(ColumnOrder++)
            .HasMaxLength(ListingEntity.ListingEntity_DescriptionMaxLength);

        builder
            .Property(listing => listing.BlobUrls)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .ToTable(TableNames.Listings)
            .HasKey(listing => listing.ListingId);

        builder
            .HasOne(listing => listing.User)
            .WithMany(user => user.Listings)
            .HasForeignKey(user => user.UserId)
            .HasPrincipalKey(listing => listing.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(listing => listing.ListingCategory)
            .WithMany(listingCategory => listingCategory.Listings)
            .HasForeignKey(listingCategory => listingCategory.CategoryId)
            .HasPrincipalKey(listing => listing.ListingCategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(listing => listing.ListingReviews)
            .WithOne(listingReviews => listingReviews.Listing)
            .HasForeignKey(listingReviews => listingReviews.ListingId)
            .HasPrincipalKey(listing => listing.ListingId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .HasIndex(listing => listing.UserId);

        builder
            .HasIndex(listing => listing.CategoryId);
    }
}
