﻿using Api.TorMarket.Application.Entities;
using Api.TorMarket.Application.Entities.Common;
using Api.TorMarket.Application.Services.Interfaces;
using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Category => Set<Category>();

    public DbSet<Listing> Listings => Set<Listing>();

    public DbSet<Photo> Photos => Set<Photo>();

    public DbSet<Review> Reviews => Set<Review>();

    public DbSet<User> User => Set<User>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = DateTime.Now;
            }

            entry.Entity.UpdatedOn = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
