using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewByUserAndListingId;

public sealed class GetReviewByUserAndListingIdHandler : IQueryHandler<GetReviewByUserAndListingIdQuery, ListingWithReviewAndCategory>
{
    private readonly IListingReviewRepository _repository;

    public GetReviewByUserAndListingIdHandler(IListingReviewRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListingWithReviewAndCategory> HandleAsync(
        GetReviewByUserAndListingIdQuery request,
        CancellationToken cancellationToken
    ) =>
        await _repository.GetByUserAndListingIdAsync(
            request.UserId,
            request.ListingId,
            cancellationToken
        );
}
