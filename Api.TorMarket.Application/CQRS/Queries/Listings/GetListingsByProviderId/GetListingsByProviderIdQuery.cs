using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByProviderId;

public sealed record GetListingsByProviderIdQuery(
    [Required] string ProviderId
) : IRequest<ResultOrError<IEnumerable<ListingWithDetails?>, GetListingsByProviderIdFailure>>;