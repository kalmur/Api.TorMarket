using Api.TorMarket.Domain.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions.Mediator;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewByUserAndListingId;

public sealed record GetReviewByUserAndListingIdQuery(
    [Required] int UserId,
    [Required] int ListingId
) : IQuery<ListingWithReviewAndCategory>;
