using Api.TorMarket.Domain.Models.ViewModels;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public sealed record GetAllListingsQuery : IRequest<IEnumerable<ListingWithUserAndCategory>>;
