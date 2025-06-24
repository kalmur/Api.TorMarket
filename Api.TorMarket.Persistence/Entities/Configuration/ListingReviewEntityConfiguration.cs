using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class ListingReviewEntityConfiguration : EntityConfigurationBase<ListingReviewEntity>
{
    protected override string TableName => TableNames.ListingReviews;

    protected override void ConfigureColumns(EntityTypeBuilder<ListingReviewEntity> builder)
    {
        builder
            .Property(listingReview => listingReview.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listingReview => listingReview.ListingId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listingReview => listingReview.Rating)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listingReview => listingReview.Comment)
            .HasColumnOrder(ColumnOrder++)
            .HasMaxLength(ListingReview.Comment_MaxLength);

        builder
            .Property(listingReview => listingReview.CreatedDate)
            .HasColumnOrder(ColumnOrder++);

        builder
            .Property(x => x.UpdatedDate)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingReviewEntity> builder)
    {
        builder
            .HasKey(
                listingReview => new 
                { 
                    listingReview.UserId, 
                    listingReview.ListingId 
                }
            );

        builder
            .HasOne(listingReview => listingReview.Listing)
            .WithMany(listing => listing.ListingReviews)
            .HasForeignKey(listingReview => listingReview.ListingId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(listingReview => listingReview.User)
            .WithMany(user => user.ListingReviews)
            .HasForeignKey(listingReview => listingReview.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingReviewEntity> builder)
    {
        builder
            .HasIndex(listingReview => new
            {
                listingReview.UserId,
                listingReview.ListingId
            })
            .IsUnique();
    }
}
