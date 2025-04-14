using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration.Common;

internal abstract class EntityConfigurationBase<T> : IEntityTypeConfiguration<T> where T : class
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(TableName);

        ConfigureColumns(builder);
        ConfigureKeys(builder);
        ConfigureIndexes(builder);
    }

    protected abstract string TableName { get; }

    public int ColumnOrder = 1;

    protected abstract void ConfigureColumns(EntityTypeBuilder<T> builder);
    protected abstract void ConfigureKeys(EntityTypeBuilder<T> builder);
    protected abstract void ConfigureIndexes(EntityTypeBuilder<T> builder);
}