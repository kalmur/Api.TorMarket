using Api.TorMarket.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewsByListingId;

public record GetReviewsByListingIdQuery(
    [Required] int ListingId
) : IRequest<IEnumerable<ListingReview>>;
