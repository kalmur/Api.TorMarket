using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;

public sealed record CreateListingReviewCommand : IRequest<ResultOrError<ListingReview, CreateListingReviewFailure>>
{
    [Required]
    public required int UserId { get; init; }

    [Required]
    public required int ListingId { get; init; }

    [Required]
    public required int Value { get; init; }

    [Required]
    public required string Comment { get; init; }

    internal CreateListingReviewRequest ToRequest()
        => new()
        {
            UserId = UserId,
            ListingId = ListingId,
            Value = Value,
            Comment = Comment,
        };
}
