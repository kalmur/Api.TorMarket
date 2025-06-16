using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetAllListings;

public sealed record GetAllListingsQuery : IQuery<IEnumerable<ListingWithDetails>>;
