using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListingById;

public sealed record GetListingByIdQuery(
    [Required] int Id
) : IRequest<ListingWithDetails>;
