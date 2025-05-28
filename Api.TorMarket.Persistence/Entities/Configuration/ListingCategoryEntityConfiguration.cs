using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class ListingCategoryEntityConfiguration : EntityConfigurationBase<ListingCategoryEntity>
{
    protected override string TableName => TableNames.ListingCategories;

    protected override void ConfigureColumns(EntityTypeBuilder<ListingCategoryEntity> builder)
    {
        builder
            .Property(listingCategory => listingCategory.ListingCategoryId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(ListingCategory.Name_MaxLength);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingCategoryEntity> builder)
    {
        builder
            .HasKey(listingCategory => listingCategory.ListingCategoryId);

        builder
            .HasMany(x => x.Listings)
            .WithOne(x => x.ListingCategory)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingCategoryEntity> builder)
    {
        builder
            .HasIndex(listingCategory => listingCategory.Name);
    }
}
