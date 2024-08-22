using MediatR;

namespace Api.TorMarket.Application.Workflows.Review.UpdateReview;

public class UpdateReviewRequest : IRequest<UpdateReviewResponse>
{
    public UpdateReviewRequest(int userId, int listingId)
    {
        UserId = userId;
        ListingId = listingId;
    }

    public int UserId { get; }
    public int ListingId { get; }
    public int? Rating { get; }
    public string Comment { get; }
}
