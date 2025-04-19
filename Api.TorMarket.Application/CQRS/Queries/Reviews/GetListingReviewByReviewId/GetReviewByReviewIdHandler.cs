using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetListingReviewByReviewId;

internal class GetReviewByReviewIdHandler(IListingReviewRepository repository) : IRequestHandler<GetReviewByReviewIdQuery, ListingWithReviewAndCategory>
{
    public async Task<ListingWithReviewAndCategory> Handle(
        GetReviewByReviewIdQuery request, 
        CancellationToken cancellationToken
    ) => await repository.GetByReviewIdAsync(
        request.ReviewId,
        cancellationToken
    );
}
