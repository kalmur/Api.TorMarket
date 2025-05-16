using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal class ListingEntityConfiguration : EntityConfigurationBase<ListingEntity>
{
    protected override string TableName => TableNames.Listings;

    protected override void ConfigureColumns(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .Property(x => x.ListingId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(x => x.CategoryId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(x => x.Price)
            .HasColumnOrder(ColumnOrder++)
            .HasColumnType("decimal(18,2)");

        builder
            .Property(x => x.Description)
            .HasColumnOrder(ColumnOrder++);

        builder
            .Property(x => x.ImageUrls)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .ToTable(TableNames.Listings)
            .HasKey(x => x.ListingId);

        builder
            .HasOne(p => p.User)
            .WithMany(u => u.Listings)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.ListingCategory)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.UserProductReviews)
            .WithOne(x => x.Listing)
            .HasForeignKey(x => x.ListingId)
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
