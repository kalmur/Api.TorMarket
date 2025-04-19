
using Api.TorMarket.Application.Repositories.Interfaces;

namespace Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;

public class CreateListingReviewValidator(
    IListingRepository listingRepository,
    IListingReviewRepository listingReviewRepository,
    IUserRepository userRepository
) : IValidator<CreateListingReviewCommand, CreateListingReviewFailure>
{
    public async Task<CreateListingReviewFailure?> ValidateAsync(
        CreateListingReviewCommand command, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<CreateListingReviewFailure.ErrorType>();

        if (await ListingDoesNotExist(command.ListingId, cancellationToken))
            errors.Add(CreateListingReviewFailure.ErrorType.ListingNotFound);

        if (await RequestingUserDoesNotExist(command.UserId, cancellationToken))
            errors.Add(CreateListingReviewFailure.ErrorType.UserNotFound);

        if (await ReviewAlreadyExists(command.UserId, command.ListingId, cancellationToken))
           errors.Add(CreateListingReviewFailure.ErrorType.ReviewAlreadyExists);

        if (command.Value > 5)
            errors.Add(CreateListingReviewFailure.ErrorType.InvalidValue);

        // Add sanitization package - Antisamy or similar
        if (string.IsNullOrWhiteSpace(command.Comment))
            errors.Add(CreateListingReviewFailure.ErrorType.InvalidComment);

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
            await listingRepository.GetByIdAsync(
                listingId,
                cancellationToken
            )
        ) is null;

    private async Task<bool> RequestingUserDoesNotExist(
        int userId,
        CancellationToken cancellationToken
    ) => (
            await userRepository.GetByIdAsync(
                userId,
                cancellationToken
            )
        ) is null;

    private async Task<bool> ReviewAlreadyExists(
        int userId,
        int listingId,
        CancellationToken cancellationToken
    ) => (
            await listingReviewRepository.GetByUserAndListingIdAsync(
                userId,
                listingId,
                cancellationToken
            )
        ) is not null;

}
