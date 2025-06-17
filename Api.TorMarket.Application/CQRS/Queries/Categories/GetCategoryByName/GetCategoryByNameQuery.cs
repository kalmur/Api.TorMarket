using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;

public sealed record GetCategoryByNameQuery(
    [Required] string Name
) : IQuery<ResultOrError<Category, GetCategoryByNameFailure>>;