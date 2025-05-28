using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;

internal sealed class CreateListingReviewHandler(
    IValidator<CreateListingReviewCommand, CreateListingReviewFailure> validator,
    IListingReviewRepository listingReviewRepository
) : IRequestHandler<CreateListingReviewCommand, ResultOrError<ListingReview, CreateListingReviewFailure>>
{
    public async Task<ResultOrError<ListingReview, CreateListingReviewFailure>> Handle(
        CreateListingReviewCommand command,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            command,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await listingReviewRepository.CreateAsync(
            command.ToRequest(),
            cancellationToken
        );
    }
}
