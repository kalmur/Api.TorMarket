using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsForUser;

public sealed record GetListingsForUserQuery : IRequest<IEnumerable<Listing>>
{
    public required string ProviderId { get; init; }
}