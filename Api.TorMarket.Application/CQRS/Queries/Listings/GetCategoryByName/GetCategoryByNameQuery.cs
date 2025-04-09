using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetCategoryByName;

public sealed record GetCategoryByNameQuery : IRequest<ResultOrError<ListingCategory, GetCategoryByNameFailure>>
{
    public required string Name { get; init; }
}