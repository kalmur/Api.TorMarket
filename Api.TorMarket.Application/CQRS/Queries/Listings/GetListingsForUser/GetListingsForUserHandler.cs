using System.Collections.Immutable;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsForUser;

public class GetListingsForUserHandler(
    IListingRepository listingRepository,
    IUserRepository userRepository
) : IRequestHandler<GetListingsForUserQuery, IEnumerable<Listing>>
{
    public async Task<IEnumerable<Listing>> Handle(
        GetListingsForUserQuery request, 
        CancellationToken cancellationToken
    )
    {
        var user = await userRepository.GetByProviderIdAsync(
            request.ProviderId, 
            cancellationToken
        );

        var listings = await listingRepository.GetByUserIdAsync(
            user.UserId, 
            cancellationToken
        );

        return listings;
    }
}
