using System.Collections.Immutable;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public class GetAllListingsQuery : IRequest<ImmutableArray<Listing>>
{
}
