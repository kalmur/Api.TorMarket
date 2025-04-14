using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingByCategoryName;

public sealed record GetListingsByCategoryNameQuery : IRequest<IEnumerable<ListingWithCategory?>>
{
    public required string CategoryName { get; init; }
}
