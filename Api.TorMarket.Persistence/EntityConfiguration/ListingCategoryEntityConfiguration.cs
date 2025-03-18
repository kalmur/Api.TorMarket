using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class ListingCategoryEntityConfiguration : EntityConfigurationBase<ListingCategoryEntity>
{
    protected override string TableName => TableNames.ListingCategory;

    protected override void ConfigureColumns(EntityTypeBuilder<ListingCategoryEntity> builder)
    {
        builder
            .Property(x => x.ListingCategoryId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingCategoryEntity> builder)
    {
        builder
            .HasKey(x => x.ListingCategoryId);

        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.ProductCategoryEntity)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ListingCategoryEntity> builder)
    {
        builder
            .HasIndex(pc => pc.Name);
    }
}
