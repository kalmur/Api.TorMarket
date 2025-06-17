using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;

public sealed record GetListingsByCategoryNameQuery(
    [Required] string CategoryName
) : IQuery<IEnumerable<ListingWithDetails?>>;