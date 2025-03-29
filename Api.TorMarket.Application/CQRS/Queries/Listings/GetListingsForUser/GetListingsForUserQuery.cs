using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;
using System.Collections.Immutable;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsForUser;

public record GetListingsForUserQuery : IRequest<ResultOrError<ImmutableArray<Listing>, GetListingsForUserFailure>>
{
    public string ProviderId { get; init; }
}