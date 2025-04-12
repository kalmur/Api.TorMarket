using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsForCategory;

public sealed record GetListingsForCategoryQuery : IRequest<IEnumerable<ListingWithCategory?>>
{
    public required string CategoryName { get; init; }
}
