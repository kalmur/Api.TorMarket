using Api.TorMarket.Domain.Results.Errors;

namespace Api.TorMarket.Application.Workflows.Review.UpdateReview;

public class UpdateReviewResponse
{
    public UpdateReviewResponse(Error error = default)
    {
        HasErrored = error is not null;
        Error = error;
    }

    public bool HasErrored { get; }
    public Error Error { get; }
}
