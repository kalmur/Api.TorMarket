using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Repositories;

namespace Api.TorMarket.Persistence.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly IApplicationDbContext _context;

    public PhotoRepository(IApplicationDbContext context)
    {
        _context = context;
    }
}
