using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Application.Interfaces;
using User = Api.TorMarket.Domain.Entities.User;

namespace Api.TorMarket.Persistence.Repositories;

public class UserRepository(IApplicationDbContext context) : IUserRepository
{
    public async Task AddUserAsync(User user, CancellationToken ct)
    {
        context.User.Add(user);
        await context.SaveChangesAsync(ct);
    }
}
