using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewsByListingId;

public sealed class GetReviewsHandler : IQueryHandler<GetReviewsByListingIdQuery, IEnumerable<ListingReview>>
{
    private readonly IListingReviewRepository _repository;

    public GetReviewsHandler(IListingReviewRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ListingReview>> HandleAsync(
        GetReviewsByListingIdQuery query,
        CancellationToken cancellationToken
    ) => await _repository.GetByListingIdAsync(
        query.ListingId,
        cancellationToken
    );
}