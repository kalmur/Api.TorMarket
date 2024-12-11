using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .ToTable(TableNames.Role)
            .HasKey(x => x.RoleId);

        builder
            .Property(x => x.RoleId)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Description);

        // Navigation
        builder
            .HasMany(x => x.Users)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seed roles data
        builder.HasData(RoleData.Roles);
    }
}
