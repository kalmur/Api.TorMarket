using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewsByListingId;

internal sealed class GetReviewsHandler(
    IListingReviewRepository repository
) : IRequestHandler<GetReviewsByListingIdQuery, IEnumerable<ListingReview>>
{
    public async Task<IEnumerable<ListingReview>> Handle(
        GetReviewsByListingIdQuery query,
        CancellationToken cancellationToken
    ) => await repository.GetByListingIdAsync(
        query.ListingId,
        cancellationToken
    );
}
