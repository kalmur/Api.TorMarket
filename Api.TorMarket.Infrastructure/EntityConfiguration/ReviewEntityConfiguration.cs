using Api.TorMarket.Application.Entities;
using Api.TorMarket.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Infrastructure.EntityConfiguration;

public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .ToTable(TableNames.Review)
            .HasKey(x => x.ReviewId);

        builder
            .Property(x => x.ReviewId)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Rating)
            .IsRequired();

        builder.Property(x => x.Comment);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Listing)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.ListingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
