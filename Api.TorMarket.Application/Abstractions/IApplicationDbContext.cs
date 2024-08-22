using Api.TorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Category> Category { get; }
    DbSet<Listing> Listings { get; }
    DbSet<Photo> Photos { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Role> Role { get; }
    DbSet<User> User { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
