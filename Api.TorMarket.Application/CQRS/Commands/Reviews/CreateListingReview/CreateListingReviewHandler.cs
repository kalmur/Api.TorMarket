using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;

public sealed class CreateListingReviewHandler : ICommandHandler<CreateListingReviewCommand, ResultOrError<ListingReview, CreateListingReviewFailure>>
{
    private readonly IValidator<CreateListingReviewCommand, CreateListingReviewFailure> _validator;
    private readonly IListingReviewRepository _listingReviewRepository;

    public CreateListingReviewHandler(
        IValidator<CreateListingReviewCommand, CreateListingReviewFailure> validator,
        IListingReviewRepository listingReviewRepository
    )
    {
        _validator = validator;
        _listingReviewRepository = listingReviewRepository;
    }

    public async Task<ResultOrError<ListingReview, CreateListingReviewFailure>> HandleAsync(
        CreateListingReviewCommand command, 
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await _validator.ValidateAsync(
            command,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await _listingReviewRepository.CreateAsync(
            command.ToRequest(),
            cancellationToken
        );
    }
}
