using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;

public sealed record GetCategoryByNameQuery(
    [Required] string Name
) : IRequest<ResultOrError<Category, GetCategoryByNameFailure>>;