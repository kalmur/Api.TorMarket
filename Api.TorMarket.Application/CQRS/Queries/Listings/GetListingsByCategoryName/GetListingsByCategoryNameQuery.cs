using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingsByCategoryName;

public sealed record GetListingsByCategoryNameQuery(
    [Required] string CategoryName
) : IRequest<IEnumerable<ListingWithDetails?>>;