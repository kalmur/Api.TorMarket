using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class ListingBlobEntityConfiguration : EntityConfigurationBase<ListingBlobEntity>
{
    protected override string TableName => TableNames.ListingBlobs;

    protected override void ConfigureColumns(EntityTypeBuilder<ListingBlobEntity> builder)
    {
        builder
            .Property(listingBlob => listingBlob.ListingBlobId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(listingBlob => listingBlob.ListingId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listingBlob => listingBlob.Url)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(ListingBlobEntity.Url_MaxLength);

        builder
            .Property(listingBlob => listingBlob.IsPrimary)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingBlobEntity> builder)
    {
        builder
            .HasKey(listingBlob => listingBlob.ListingBlobId);

        builder
            .HasOne(listingBlob => listingBlob.Listing)
            .WithMany(listing => listing.ListingBlobs)
            .HasForeignKey(listingBlob => listingBlob.ListingId)
            .HasPrincipalKey(listing => listing.ListingId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingBlobEntity> builder)
    {
        builder
            .HasIndex(listingBlob => listingBlob.ListingId);

        builder
            .HasIndex(listingBlob => listingBlob.Url)
            .IsUnique();
    }
}
