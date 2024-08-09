using Api.TorMarket.Application.Entities;
using Api.TorMarket.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Infrastructure.EntityConfiguration;

public class ListingEntityConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder
            .ToTable(TableNames.Listings)
            .HasKey(x => x.ListingId);

        builder
            .Property(x => x.ListingId)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .Property(x => x.SellLease)
            .IsRequired();

        builder.Property(x => x.Description);

        builder
            .Property(x => x.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.City);
        builder.Property(x => x.Country);
        builder.Property(x => x.AvailableFrom);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Listings)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Listings)
            .HasForeignKey(x => x.CategoryId);

        builder
            .HasMany(x => x.Reviews)
            .WithOne(x => x.Listing)
            .HasForeignKey(x => x.ListingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Photos)
            .WithOne(x => x.Listing)
            .HasForeignKey(x => x.ListingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
