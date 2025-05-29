using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class ListingEntityConfiguration : EntityConfigurationBase<ListingEntity>
{
    protected override string TableName => TableNames.Listings;

    protected override void ConfigureColumns(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .Property(listing => listing.ListingId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(listing => listing.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listing => listing.CategoryId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(listing => listing.Name)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(Listing.Name_MaxLength);

        builder
            .Property(listing => listing.Price)
            .HasColumnOrder(ColumnOrder++)
            .HasColumnType(Listing.Price_ColumnType);

        builder
            .Property(listing => listing.Description)
            .HasColumnOrder(ColumnOrder++)
            .HasMaxLength(Listing.Description_MaxLength);

        builder
            .Property(user => user.CreatedDate)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(user => user.UpdatedDate)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .HasKey(listing => listing.ListingId);

        builder
            .HasOne(listing => listing.Category)
            .WithMany(listingCategory => listingCategory.Listings)
            .HasForeignKey(listing => listing.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(listing => listing.User)
            .WithMany(u => u.Listings)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .HasIndex(pr => pr.UserId);

        builder
            .HasIndex(pr => pr.CategoryId);
    }
}
