using System.Collections.Immutable;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Listings.Queries.GetAllListings;

public class GetAllListingsQuery : IRequest<ImmutableArray<Listing>>
{
}
