using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetAllCategories;

public sealed record GetAllCategoriesQuery : IQuery<IEnumerable<Category>>;
