using System.Collections.Immutable;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsForUser;

public class GetListingsForUserHandler(
    IListingRepository listingRepository,
    IUserRepository userRepository
) : IRequestHandler<GetListingsForUserQuery, ResultOrError<ImmutableArray<Listing>, GetListingsForUserFailure>>
{
    public async Task<ResultOrError<ImmutableArray<Listing>, GetListingsForUserFailure>> Handle(
        GetListingsForUserQuery request, 
        CancellationToken cancellationToken
    )
    {
        var user = await userRepository.GetByProviderIdAsync(
            request.ProviderId, 
            cancellationToken
        );

        var listings = await listingRepository.GetListingsForUserAsync(
            user.UserId, 
            cancellationToken
        );
    }
}
