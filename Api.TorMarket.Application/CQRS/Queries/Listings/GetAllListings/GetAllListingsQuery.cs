using System.Collections.Immutable;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public sealed class GetAllListingsQuery : IRequest<ImmutableArray<ListingWithUserAndCategory>>
{
}
