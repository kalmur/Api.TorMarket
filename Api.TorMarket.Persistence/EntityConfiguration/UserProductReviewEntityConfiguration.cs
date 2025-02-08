using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class UserProductReviewEntityConfiguration : IEntityTypeConfiguration<UserProductReview>
{
    public void Configure(EntityTypeBuilder<UserProductReview> builder)
    {
        builder
            .ToTable(TableNames.UserProductReview)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.UserId)
            .IsRequired();

        builder
            .Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.RatingValue);

        builder.Property(x => x.Comment);

        // Navigation
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserProductReviews)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.UserProductReviews)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
