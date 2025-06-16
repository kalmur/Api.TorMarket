using Api.TorMarket.Domain.Models;
using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Mediator;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewsByListingId;

public sealed record GetReviewsByListingIdQuery(
    [Required] int ListingId
) : IQuery<IEnumerable<ListingReview>>;
