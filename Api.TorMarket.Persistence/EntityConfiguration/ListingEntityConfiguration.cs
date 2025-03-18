using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class ListingEntityConfiguration : EntityConfigurationBase<ListingEntity>
{
    protected override string TableName => TableNames.Listing;

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
            .Property(x => x.AvailableFrom)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ListingEntity> builder)
    {
        builder
            .ToTable(TableNames.Listing)
            .HasKey(x => x.ListingId);

        builder
            .HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.ProductCategoryEntity)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.UserProductReviews)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
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
