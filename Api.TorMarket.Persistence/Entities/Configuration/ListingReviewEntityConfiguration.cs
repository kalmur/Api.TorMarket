using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal class ListingReviewEntityConfiguration : EntityConfigurationBase<ListingReviewEntity>
{
    protected override string TableName => TableNames.ListingReviews;

    protected override void ConfigureColumns(EntityTypeBuilder<ListingReviewEntity> builder)
    {
        builder
            .Property(x => x.ListingReviewId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.UserId)
            .IsRequired();

        builder
            .Property(x => x.ListingId)
            .IsRequired();

        builder
            .Property(x => x.Value);

        builder
            .Property(x => x.Comment);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingReviewEntity> builder)
    {
        builder
            .HasKey(x => x.ListingReviewId);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.ProductReviews)
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

        builder
            .HasIndex(pr => pr.UserId);

        builder
            .HasIndex(pr => pr.ListingId);
    }
}
