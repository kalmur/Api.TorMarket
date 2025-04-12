using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetAllCategories;

public sealed record GetAllCategoriesRequest : IRequest<IEnumerable<ListingCategory>>
{
}
