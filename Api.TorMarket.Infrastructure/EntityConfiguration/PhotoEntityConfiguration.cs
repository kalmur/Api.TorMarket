using Api.TorMarket.Application.Entities;
using Api.TorMarket.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Infrastructure.EntityConfiguration;

public class PhotoEntityConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.ToTable(TableNames.Photos).HasKey(x => x.PhotoId);

        builder.Property(x => x.PhotoId).ValueGeneratedOnAdd();

        builder.Property(x => x.Url);

        builder.Property(x => x.IsPrimary);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Photos)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Listing)
            .WithMany(x => x.Photos)
            .HasForeignKey(x => x.ListingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
