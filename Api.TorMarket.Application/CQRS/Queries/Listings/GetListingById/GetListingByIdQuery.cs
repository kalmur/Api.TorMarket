using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingById;

public sealed record GetListingByIdQuery(
    [Required] int Id
) : IQuery<ListingWithDetails>;
