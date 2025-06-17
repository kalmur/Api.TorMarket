using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewByUserAndListingId;

public sealed class GetReviewByUserAndListingIdHandler(
    IListingReviewRepository repository
) : IQueryHandler<GetReviewByUserAndListingIdQuery, ListingWithReviewAndCategory>
{
    public async Task<ListingWithReviewAndCategory> HandleAsync(
        GetReviewByUserAndListingIdQuery request, 
        CancellationToken cancellationToken
    ) => 
        await repository.GetByUserAndListingIdAsync(
            request.UserId,
            request.ListingId,
            cancellationToken
        );
}
