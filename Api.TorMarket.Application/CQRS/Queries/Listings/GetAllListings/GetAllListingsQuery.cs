using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Repositories;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public sealed record GetAllListingsQuery(
    PaginatedRequest PaginatedRequest
) : IQuery<PaginatedResult<ListingWithDetails>>;
