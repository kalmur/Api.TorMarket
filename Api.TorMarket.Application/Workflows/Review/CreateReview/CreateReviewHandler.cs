using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.TorMarket.Application.Workflows.Review.CreateReview;

public class CreateReviewHandler : INotificationHandler<CreateReviewNotification>
{
    private readonly IUserProductReviewRepository _repository;
    private readonly ILogger<CreateReviewHandler> _logger;

    public CreateReviewHandler(IUserProductReviewRepository repository, ILogger<CreateReviewHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task Handle(CreateReviewNotification notification, CancellationToken cancellationToken)
    {
        var review = notification.ToEntity();

        await _repository.AddReviewAsync(review, cancellationToken);

        _logger.LogInformation("Review created.");
    }
}