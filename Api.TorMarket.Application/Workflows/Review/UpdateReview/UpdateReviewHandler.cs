using Api.TorMarket.Application.Abstractions;
using Api.TorMarket.Domain.Results.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.TorMarket.Application.Workflows.Review.UpdateReview;

public class UpdateReviewHandler : IRequestHandler<UpdateReviewRequest, UpdateReviewResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<UpdateReviewHandler> _logger;

    public UpdateReviewHandler(IApplicationDbContext context, ILogger<UpdateReviewHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<UpdateReviewResponse> Handle(UpdateReviewRequest request, CancellationToken cancellationToken)
    {
        var reviewToUpdate = await _context.Reviews.SingleOrDefaultAsync(x => 
                    x.UserId == request.UserId && 
                    x.ListingId == request.ListingId,
                    cancellationToken
        );

        if (reviewToUpdate is null)
        {
            return new UpdateReviewResponse
            (
                error: new NotFoundError($"{request.ListingId}", "Review")
            );
        }

        reviewToUpdate.Rating = request.Rating;
        reviewToUpdate.Comment = request.Comment;

        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateReviewResponse();
    }
}

