using Api.TorMarket.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewsByListingId;

public sealed record GetReviewsByListingIdQuery(
    [Required] int ListingId
) : IRequest<IEnumerable<ListingReview>>;
