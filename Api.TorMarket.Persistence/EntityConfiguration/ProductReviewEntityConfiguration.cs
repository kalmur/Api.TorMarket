using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class ProductReviewEntityConfiguration : EntityConfigurationBase<ProductReviewEntity>
{
    protected override string TableName => TableNames.ProductReviews;

    protected override void ConfigureColumns(EntityTypeBuilder<ProductReviewEntity> builder)
    {
        builder
            .Property(x => x.Id)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.UserId)
            .IsRequired();

        builder
            .Property(x => x.ProductId)
            .IsRequired();

        builder
            .Property(x => x.RatingValue);

        builder
            .Property(x => x.Comment);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ProductReviewEntity> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.ProductReviews)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.UserProductReviews)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ProductReviewEntity> builder)
    {
        builder
            .HasIndex(pr => new
            {
                pr.UserId,
                pr.ProductId
            })
            .IsUnique();

        builder
            .HasIndex(pr => pr.UserId);

        builder
            .HasIndex(pr => pr.ProductId);
    }
}
