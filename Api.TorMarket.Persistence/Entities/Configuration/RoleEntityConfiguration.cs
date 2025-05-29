using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal class RoleEntityConfiguration : EntityConfigurationBase<RoleEntity>
{
    protected override string TableName => TableNames.Roles;

    protected override void ConfigureColumns(EntityTypeBuilder<RoleEntity> builder)
    {
        builder
            .Property(role => role.RoleId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(user => user.Name)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(Role.Name_MaxLength);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<RoleEntity> builder)
    {
        builder
            .HasKey(role => role.RoleId);

        builder
            .HasMany(role => role.Users)
            .WithOne(user => user.Role)
            .HasForeignKey(user => user.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<RoleEntity> builder)
    {
        builder
            .HasIndex(role => role.Name)
            .IsUnique();
    }
}

