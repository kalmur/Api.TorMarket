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
            .Property(x => x.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(x => x.ListingId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(x => x.RatingValue)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(x => x.Comment)
            .HasColumnOrder(ColumnOrder++)
            .HasMaxLength(ListingReview.Comment_MaxLength);

        builder
            .Property(x => x.CreatedDate)
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
            .HasOne(x => x.Listing)
            .WithMany(x => x.ListingReviews)
            .HasForeignKey(x => x.ListingId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(listingReview => listingReview.User)
            .WithMany(x => x.ListingReviews)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingReviewEntity> builder)
    {
        // TODO - Remove in case there are too many updates on the entity
        builder
            .HasIndex(pr => new
            {
                pr.UserId,
                pr.ListingId
            })
            .IsUnique();
    }
}
