using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewsByListingId;

public sealed class GetReviewsHandler(
    IListingReviewRepository repository
) : IQueryHandler<GetReviewsByListingIdQuery, IEnumerable<ListingReview>>
{
    public async Task<IEnumerable<ListingReview>> HandleAsync(
        GetReviewsByListingIdQuery query,
        CancellationToken cancellationToken
    ) => await repository.GetByListingIdAsync(
        query.ListingId,
        cancellationToken
    );
}
