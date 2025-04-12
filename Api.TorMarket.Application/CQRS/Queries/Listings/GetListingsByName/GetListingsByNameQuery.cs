using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListing;

public sealed record GetListingsByNameQuery : IRequest<ResultOrError<IEnumerable<ListingWithCategory>, GetListingsByNameFailure>>
{
    public required string Name { get; init; }
}
