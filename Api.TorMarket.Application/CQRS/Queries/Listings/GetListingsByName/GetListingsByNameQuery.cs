using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByName;

public sealed record GetListingsByNameQuery(
    [Required] string Name
) : IRequest<ResultOrError<IEnumerable<ListingWithCategory>, GetListingsByNameFailure>>;
