using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;

public sealed record GetListingsByProviderIdQuery(
    [Required] string ProviderId
) : IQuery<ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByProviderIdFailure>>;