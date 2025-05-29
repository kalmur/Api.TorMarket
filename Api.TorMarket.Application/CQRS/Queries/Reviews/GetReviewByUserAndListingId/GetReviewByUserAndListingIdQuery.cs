using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewByUserAndListingId;

public sealed record GetReviewByUserAndListingIdQuery(
    [Required] int UserId,
    [Required] int ListingId
) : IRequest<ListingWithReviewAndCategory>;
