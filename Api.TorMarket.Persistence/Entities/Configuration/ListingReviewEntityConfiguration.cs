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
            .HasColumnOrder(ColumnOrder++);

        builder
            .Property(x => x.CreatedOn)
            .HasColumnOrder(ColumnOrder++);

        builder
            .Property(x => x.UpdatedOn)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingReviewEntity> builder)
    {
        builder
            .HasKey(x => new 
            { 
                x.UserId, 
                x.ListingId 
            }
        );

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.ListingReviews)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Listing)
            .WithMany(x => x.UserProductReviews)
            .HasForeignKey(x => x.ListingId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingReviewEntity> builder)
    {
        builder
            .HasIndex(pr => new
            {
                pr.UserId,
                pr.ListingId
            })
            .IsUnique();
    }
}
