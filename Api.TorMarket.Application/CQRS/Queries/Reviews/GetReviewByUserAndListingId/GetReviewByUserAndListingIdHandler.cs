using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewByUserAndListingId;

internal sealed class GetReviewByUserAndListingIdHandler(
    IListingReviewRepository repository
) : IRequestHandler<GetReviewByUserAndListingIdQuery, ListingWithReviewAndCategory>
{
    public async Task<ListingWithReviewAndCategory> Handle(
        GetReviewByUserAndListingIdQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetByUserAndListingIdAsync(
        request.UserId,
        request.ListingId,
        cancellationToken
    );
}
