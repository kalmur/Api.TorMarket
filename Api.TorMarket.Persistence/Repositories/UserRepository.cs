using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Repositories;
using User = Api.TorMarket.Domain.Entities.User;

namespace Api.TorMarket.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(User user, CancellationToken ct)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync(ct);
    }
}
