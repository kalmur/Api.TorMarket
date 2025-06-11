using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Api.TorMarket.Persistence.Context;
using Api.TorMarket.Persistence.Entities;
using NUnit.Framework;

namespace Api.TorMarket.Persistence.Tests.Repositories;

internal class RepositoryTestsBase
{
    private const string SqliteConnectionString = "DataSource=:memory:";

    private SqliteConnection _sqliteConnection = null!;

    protected ApplicationDbContext _dbContext = null!;
    protected CancellationToken _cancellationToken = CancellationToken.None;

    [OneTimeSetUp]
    public void OneTimeSetupBase()
    {
        _sqliteConnection = new SqliteConnection(SqliteConnectionString);
        _sqliteConnection.CreateFunction("SysUtcDateTime", () => DateTime.UtcNow);
        _sqliteConnection.Open();

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(_sqliteConnection)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();

        _dbContext = new ApplicationDbContext(
            dbContextOptionsBuilder.Options
        );

        _dbContext.Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.ChangeTracker.Clear();
        RemoveAllEntities();
    }

    [OneTimeTearDown]
    public void OneTimeTearDownBase()
    {
        _sqliteConnection.Close();
        _sqliteConnection.Dispose();
        _dbContext.Dispose();
    }

    protected UserEntity GenerateUserEntity(
        int? roleId = null,
        string? providerId = null
    ) => AddEntity(
        new UserEntity()
        {
            UserId = GenerateNextUserId(),
            RoleId = roleId ?? GenerateNextRoleId(),
            ProviderId = providerId ?? GenerateNextProviderId()
        }
    );

    protected int GenerateNextUserId() =>
        GenerateNextId<UserEntity>(
            user => user.UserId
        );

    protected int GenerateNextRoleId() =>
        GenerateNextId<UserEntity>(
            user => user.RoleId
        );

    protected string GenerateNextProviderId() =>
        GenerateNextName<UserEntity>(
            "User",
            user => user.ProviderId
        );

    private int GenerateNextId<TEntityType>(
        Func<TEntityType, int> selector
    ) where TEntityType : class
    {
        var entities = _dbContext.Set<TEntityType>().ToList();

        return entities.Count == 0
            ? 1
            : entities
                .Max(selector) + 1;
    }

    private string GenerateNextName<TEntityType>(
        string namePrefix,
        Func<TEntityType, string> selector
    ) where TEntityType : class
    {
        string nameGenerator(int entityNumber) => $"{namePrefix} {entityNumber}";

        var counter = 1;
        var name = nameGenerator(counter);
        var existingEntities = _dbContext.Set<TEntityType>().ToList();

        while (
            existingEntities is not null
            && existingEntities.Count > 0
            && existingEntities
                .Any(entity => selector(entity) == name))
        {
            counter++;
            name = nameGenerator(counter);
        }

        return name;
    }

    private TEntityType AddEntity<TEntityType>(
        TEntityType entity
    ) where TEntityType : class
    {
        if (!_dbContext.Set<TEntityType>().Contains(entity))
        {
            _dbContext.Set<TEntityType>().Add(entity);
        }
        _dbContext.SaveChanges();

        return entity;
    }

    private void RemoveAllEntitiesOfType<TEntityType>() 
        where TEntityType : class
    {
        _dbContext.Set<TEntityType>()
            .RemoveRange(
                _dbContext.Set<TEntityType>()
            );

        _dbContext.SaveChanges();
    }

    private void RemoveAllEntities()
    {
        //RemoveAllEntitiesOfType<>();
    }
}
