using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;

public sealed class CreateListingReviewHandler(
    IValidator<CreateListingReviewCommand, CreateListingReviewFailure> validator,
    IListingReviewRepository listingReviewRepository
) : ICommandHandler<CreateListingReviewCommand, ResultOrError<ListingReview, CreateListingReviewFailure>>
{
    public async Task<ResultOrError<ListingReview, CreateListingReviewFailure>> HandleAsync(
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
