using Api.TorMarket.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetListingReviewByReviewId;

public sealed record GetReviewByReviewIdQuery(
    [Required] int ReviewId
) : IRequest<ListingWithReviewAndCategory>;
