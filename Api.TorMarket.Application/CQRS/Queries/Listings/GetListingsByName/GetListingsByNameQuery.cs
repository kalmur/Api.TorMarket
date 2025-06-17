using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;

public sealed record GetListingsByNameQuery(
    [Required] string Name
) : IQuery<ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByNameFailure>>;
