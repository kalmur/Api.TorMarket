using Api.TorMarket.Application.Repositories;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public sealed record GetAllListingsQuery(
    PaginatedRequest PaginatedRequest
) : IRequest<PaginatedResult<ListingWithDetails>>;
