using Api.TorMarket.Application.Repositories.Interfaces;

namespace Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;

public sealed class CreateListingReviewValidator : IValidator<CreateListingReviewCommand, CreateListingReviewFailure>
{
    private readonly IListingRepository _listingRepository;
    private readonly IListingReviewRepository _listingReviewRepository;
    private readonly IUserRepository _userRepository;

    public CreateListingReviewValidator(
        IListingRepository listingRepository,
        IListingReviewRepository listingReviewRepository,
        IUserRepository userRepository
    )
    {
        _listingRepository = listingRepository;
        _listingReviewRepository = listingReviewRepository;
        _userRepository = userRepository;
    }

    public async Task<CreateListingReviewFailure?> ValidateAsync(
        CreateListingReviewCommand command,
        CancellationToken cancellationToken
    )
    {
        var errors = new List<CreateListingReviewFailure.ErrorType>();

        //TODO - Add sanitization package down the line - Antisamy
        if (string.IsNullOrWhiteSpace(command.Comment))
            errors.Add(CreateListingReviewFailure.ErrorType.InvalidComment);

        if (command.Value > 5)
            errors.Add(CreateListingReviewFailure.ErrorType.InvalidValue);

        if (await ListingDoesNotExist(command.ListingId, cancellationToken))
            errors.Add(CreateListingReviewFailure.ErrorType.ListingNotFound);

        if (await RequestingUserDoesNotExist(command.UserId, cancellationToken))
            errors.Add(CreateListingReviewFailure.ErrorType.UserNotFound);

        // Ensure idempotency
        if (await ReviewAlreadyExists(command.UserId, command.ListingId, cancellationToken))
            errors.Add(CreateListingReviewFailure.ErrorType.ReviewAlreadyExists);

        if (errors.Count > 0)
        {
            return new CreateListingReviewFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> ListingDoesNotExist(
        int listingId,
        CancellationToken cancellationToken
    ) => (
            await _listingRepository.GetByIdAsync(
                listingId,
                cancellationToken
            )
        ) is null;

    private async Task<bool> RequestingUserDoesNotExist(
        int userId,
        CancellationToken cancellationToken
    ) => (
            await _userRepository.GetByIdAsync(
                userId,
                cancellationToken
            )
        ) is null;

    private async Task<bool> ReviewAlreadyExists(
        int userId,
        int listingId,
        CancellationToken cancellationToken
    ) => (
            await _listingReviewRepository.GetByUserAndListingIdAsync(
                userId,
                listingId,
                cancellationToken
            )
        ) is not null;

}